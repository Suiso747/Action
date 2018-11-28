using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grenade : MonoBehaviour
{

    public float init_speed;
    public float acceleration;

    public float power;

    private GameObject enemy_explosion;
    public GameObject bullet_explosion;
    public GameObject DamageUI;
    public GameObject DamageText;

    private Rigidbody rb;
    private float damage_sum;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * init_speed;
        damage_sum = 0;



    }

    private void FixedUpdate()
    {
        rb.velocity += transform.forward * acceleration * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag != "Boundary" && other.tag == "Enemy")
            Damage(other);      

    }

    private void OnTriggerExit(Collider other)
    {
        if (damage_sum > 0)
        {
            string text = DamageText.GetComponent<Text>().text;
            GameObject DU = Instantiate(DamageUI, Camera.main.WorldToScreenPoint(this.transform.position), DamageUI.transform.rotation);

            DU.GetComponent<DamageUI>().fadeOutSpeed = 0.75f;
            DU.GetComponentInChildren<Text>().transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
            DU.GetComponentInChildren<Text>().fontSize = 32;
            DU.GetComponentInChildren<Text>().color = new Color(0, 1, 1, 0);
            DU.GetComponentInChildren<Text>().text = "" + damage_sum;

        }

        damage_sum = 0;
    }

    void Damage(Collider other)
    {
        
        power = Mathf.Floor(Random.Range(power * 0.9f, power));
        if (power <= 0) power = 1;
        damage_sum += power;

        var enemy = other.gameObject.GetComponent<DestroyByContact>();
        //var gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        //var gc = GameObject.Find("Game Controller").GetComponent<GameController>();
        string text = DamageText.GetComponent<Text>().text;

        enemy.asteroid_current_hp -= power;

        var random = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-4.0f, 4.0f), Random.Range(0.0f, 0.0f));

        text = "" + power;


        GameObject DU = Instantiate(DamageUI, Camera.main.WorldToScreenPoint(this.transform.position), DamageUI.transform.rotation);
        Debug.Log(Camera.main.WorldToScreenPoint(this.transform.position));
        DU.GetComponentInChildren<Text>().transform.position = Camera.main.WorldToScreenPoint(this.transform.position) + random;
        DU.GetComponentInChildren<Text>().text = "" + power;


        if (enemy.asteroid_current_hp <= 0)
        {
            // エネミー破壊/爆発
            enemy_explosion = enemy.explosion; 
            Instantiate(enemy_explosion, other.transform.position, other.transform.rotation);

     //       switch (Parameter.STAGE)
      //      {
       //         case 1:
        //            GameObject.FindWithTag("GameController").GetComponent<GameController_Stage1>().AddScore(enemy.scoreValue);
         //           break;
          //      default:
                    GameObject.FindWithTag("GameController").GetComponent<GameController>().AddScore(enemy.scoreValue);
          //          break;
           // }

            //Destroy(other.gameObject);
            enemy.death();

            DU.GetComponentInChildren<Text>().transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
            DU.GetComponentInChildren<Text>().fontSize = 30;
            DU.GetComponentInChildren<Text>().color = new Color(0, 64, 255, 0);
            DU.GetComponentInChildren<Text>().text = "" + damage_sum;

        }
        else
        {
            // 弾が爆発しないんだなあ
            Instantiate(bullet_explosion, transform.position, transform.rotation);
            //Destroy(gameObject);
           
        }
    }

}

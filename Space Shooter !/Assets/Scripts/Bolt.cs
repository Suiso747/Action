using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bolt : MonoBehaviour {

    public float speed;
    public float power;
    public float lifetime; // 要は射程


    private GameObject enemy_explosion;
    public GameObject bullet_explosion;
    public GameObject DamageUI;
    public GameObject DamageText;


    private void Start()
    {
        power = Mathf.Floor(Random.Range(power * 0.85f, power));
        Destroy(gameObject, lifetime);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

     
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Boundary" && other.tag == "Enemy")
            Damage(other);

    }

    void Damage(Collider other){



        var enemy = other.gameObject.GetComponent<DestroyByContact>();
       
        string text = DamageText.GetComponent<Text>().text;

        enemy.asteroid_current_hp -= power;

        var random = new Vector3(Random.Range(-18.0f, 18.0f), Random.Range(-18.0f, 18.0f), Random.Range(0.0f, 0.0f));

        text = "" + power;


        GameObject DU = Instantiate(DamageUI, Camera.main.WorldToScreenPoint(this.transform.position), DamageUI.transform.rotation);
        Debug.Log(Camera.main.WorldToScreenPoint(this.transform.position));
        DU.GetComponentInChildren<Text>().transform.position = Camera.main.WorldToScreenPoint(this.transform.position) + random;
        DU.GetComponentInChildren<Text>().text = ""+power;

        if (enemy.asteroid_current_hp <= 0){
            // エネミー破壊/爆発
            enemy_explosion = enemy.explosion;
            Instantiate(enemy_explosion, other.transform.position, other.transform.rotation);



            //switch (Parameter.CURRENT_STAGE)
            //{
            //    case 1:
            //        GameObject.FindWithTag("GameController").GetComponent<GameController_Stage1>().AddScore(enemy.scoreValue);
            //        //var gc1 = GameObject.FindWithTag("GameController").GetComponent<GameController_Stage1>();
            //        break;
            //    default:
                    GameObject.FindWithTag("GameController").GetComponent<GameController>().AddScore(enemy.scoreValue);
            //        break;
            //}           

            enemy.death();
            //Destroy(other.gameObject);

        }else{
            // 弾が爆発
            Instantiate(bullet_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

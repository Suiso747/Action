using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public int scoreValue;
    public GameObject[] treasure;
    public int treasure_max;

    public float asteroid_full_hp;
    public float asteroid_current_hp;

    private void Start()
    {
        asteroid_current_hp = asteroid_full_hp;
    }

    public void death()
    {
        //落とすお宝の数を決定する
        int treasure_n = Random.Range(1, treasure_max);

        for (int i = 0; i < treasure_n; i++){
            Vector3 random = new Vector3(Random.Range(-0.3f*i, 0.3f*i), Random.Range(-0.1f, 0.1f), Random.Range(-0.3f*i, 0.3f*i));
            Instantiate(treasure[Random.Range(0,treasure.Length)], transform.position+random, transform.rotation);
        }

        Destroy(gameObject);
    }



    /* void OnCollisionEnter(Collider other)
     {
         if (other.tag != "Boundary")
         {
             float power = other.gameObject.GetComponent<Bolt>().power;



             if (other.gameObject.Damage(power))
             {
                 Instantiate(explosion, other.transform.position, transform.rotation);
                 Destroy(gameObject);
             }
         }

     }*/
    /*
    public bool Damage(float power){



        asteroid_current_hp -= 1.0f;
        if (asteroid_current_hp > 0.0f)
        {
            return true;
        }
        else
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);

            return false;

        }
    }
   */
}

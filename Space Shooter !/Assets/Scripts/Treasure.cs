using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {

    public int value;
    public int child;

       
    AudioSource[] sources;




	// Use this for initialization
	void Start () {
        sources = GetComponents<AudioSource>();
        StartCoroutine(remove());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float rotate = 1.0f * Time.deltaTime;
        transform.Rotate(new Vector3(0.0f, rotate * 50, 0.0f));
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){

            //Debug.Log(value);
            // int i = Random.Range(0, se.Length - 1);
            // Debug.Log(se.Length);
            //se[i].Play();
            // AS.clip = se[0];

            if (value >= 1){
                sources[(int)Random.Range(0, 4)].Play();

                Parameter.STAGE_MONEY += value;

            }
          
            if (child >= 1)
            {
                other.gameObject.GetComponent<PlayerController>().AddChild();
                sources[0].Play();
            }
           // gameObject.SetActive(false);
            //this.transform.position = new Vector3(0,0,0);
            //transform.localScale = new Vector3(0, 0, 0);
            Renderer rend = GetComponent<Renderer>(); 
            rend.enabled = false; 

            Destroy(gameObject, 0.5f);
        }
    }
   
    IEnumerator remove(){

       
        yield return new WaitForSeconds(6);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.2f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.2f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.2f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        yield return new WaitForSeconds(0.05f);

        Destroy(gameObject);

    }


}

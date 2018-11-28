using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChildrenShot : MonoBehaviour {

    public GameObject shot;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("ChildrenFire");
	}
	


    IEnumerator ChildrenFire(){

        while(true){
            yield return new WaitForSeconds(Random.Range(0.2f,0.5f));
            Instantiate(shot, this.transform.position, this.transform.rotation);
            //GameObject clone = Instantiate(shot, this.transform.position, this.transform.rotation) as GameObject;
            //clone.GetComponent<Bolt>().power /= 2;
            audioSource.Play();
        }

    }
}

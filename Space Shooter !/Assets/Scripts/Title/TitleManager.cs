using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public Image white;
    public Image logo;


	// Use this for initialization
	void Start () {

        white = GameObject.Find("White").GetComponent<Image>();
        logo = GameObject.Find("TitleLogo").GetComponent<Image>();


        StartCoroutine("TitleLogo");


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TitleLogo(){

        yield return new WaitForSeconds(1.0f);
        Destroy(white, 1.0f);
        Destroy(logo, 1.0f);
    }
}

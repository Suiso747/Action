using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour {
    
    public GameObject[] stage;

	// Use this for initialization
	void Start () {
        for (int i = 1; i < stage.Length; i++){
            if (Parameter.STAGE_CLEARED[i] == 1)
            {
                stage[(i + 1) % stage.Length].SetActive(true);

            }
        }
       
            
	}

}

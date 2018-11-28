using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour {

    float rotate = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rotate = 1.0f * Time.deltaTime;
        transform.Rotate(new Vector3(0.0f, rotate * 1, 0.0f));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;


	// Use this for initialization
	void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        speed = Random.Range(speed - 0.6f, speed + 0.6f);
        Mathf.Abs(speed);
        rb.velocity = new Vector3(0.0f, 0.0f, -speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

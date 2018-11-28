using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBolt : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, 0.0f, -speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RondamRotator : MonoBehaviour {

    public float max_tumble; // 小惑星の回転
    private float tumble;

    Rigidbody rb;

    void Start()
    {
        max_tumble = Mathf.Max(1.0f, max_tumble);
        tumble = Random.Range(1.0f,max_tumble);
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
        //rb.angularVelocity = new Vector3(1, 1, 1)*tumble;
        //transform.position += new Vector3(0,0,1);
    }


}

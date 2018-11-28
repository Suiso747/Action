using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ChildBehavior : MonoBehaviour {
    
    public float child_delay_value;//大きいほど遅延

    private Vector3 offset;
    private List<Vector3> v3 = new List<Vector3>{};
    private Vector3 tmp_pos;

    GameObject player;


	// Use this for initialization
    // リストへオフセット(原点)を格納
    void Start () {

        //var tagObjects = GameObject.FindGameObjectsWithTag("Child");
        //int n_child = tagObjects.Length;

        player = GameObject.FindWithTag("Player");
       // child_delay_value = player.GetComponent<PlayerController>().delay;
        offset = transform.position;
        for (int i = 0; i < child_delay_value -1; i++){
            v3.Add(offset);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        tmp_pos = player.transform.position;
        tmp_pos.y = transform.position.y;
        tmp_pos.z -= 0.25f;
        // 現在のPlayerの座標をリスト末尾へ格納
        v3.Add(tmp_pos);

        // リスト先頭の要素を取り出し、その座標へ移動
        transform.position = v3[0];
        v3.RemoveAt(0); // リスト先頭の要素を消す
	}



}

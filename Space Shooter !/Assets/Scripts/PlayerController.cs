using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable] public class Boundary{
    
    public float xMin, xMax, zMin, zMax;

}


public class PlayerController : MonoBehaviour {


    public float speed;
    public float tilt; 
    public Boundary boundary;

    public GameObject shot;
    public GameObject grenade;

    public Transform shotSpawn;

    public float fireRate_shot;
    public float fireRate_grenade;

    public GameObject explosion;

    private float nextFire;
 
  
    [HideInInspector] public float player_current_hp;

    private AudioSource[] audioSources;
    AudioSource SE1, SE2, SE3;

   
    [HideInInspector] public float MP;
    public float MPcost;


    [HideInInspector] public float SP;
    public float SPcost;

    public GameObject HPSlider;
    public Slider hpSlider;

    public GameObject MPSlider;
    public Slider mpSlider;

    public GameObject SPSlider;
    public Slider spSlider;


    public GameObject child;
    public float delay;

    private void Start()
    {

        audioSources = GetComponents<AudioSource>();
        SE1 = audioSources[0];
        SE2 = audioSources[1];
        SE3 = audioSources[2];

        hpSlider = HPSlider.GetComponent<Slider>();
        hpSlider.value = hpSlider.maxValue;
        player_current_hp = hpSlider.maxValue;

        spSlider = SPSlider.GetComponent<Slider>();
        spSlider.value = spSlider.maxValue;
        SP = spSlider.maxValue;

        mpSlider = MPSlider.GetComponent<Slider>();
        mpSlider.value = mpSlider.maxValue;
        MP = mpSlider.maxValue;

       

        int child_n = Parameter.CHILD;
        for (int i = 0; i < child_n; i++){
            delay = i * 20 + 10;
            GameObject clone = Instantiate(child, new Vector3(transform.position.x,transform.position.y - 0.2f,transform.position.z), transform.rotation) as GameObject;
            clone.GetComponent<ChildBehavior>().child_delay_value = i * 20 + 10;
            Destroy(clone, 20f);
        }

    }
    public void AddChild(){
        /*
        // 一応消しとく
        GameObject[] children = GameObject.FindGameObjectsWithTag("Child");
        for (int i = 0; i < children.Length; i++)
        {
           // Instantiate(explosion, child[i].transform.position, child[i].transform.rotation);
            Destroy(children[i].gameObject);
        }
        */
        // 再生成
        int child_n = GameObject.FindGameObjectsWithTag("Child").Length;

        delay = child_n * 20 + 10;
        GameObject clone = Instantiate(child, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), transform.rotation) as GameObject;
        clone.GetComponent<ChildBehavior>().child_delay_value = child_n * 20 + 10;
        Destroy(clone, 20f);


    }


    private void Update()
    {

        RecoveryMP(0.2f);
        mpSlider.value = MP;

        RecoverySP(0.03f);
        spSlider.value = SP;



        if (Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate_shot;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); 

            //AudioSource se = GetComponent<AudioSource>();
            SE1.Play();

        }

        if (Input.GetButton("Fire2") && Time.time > nextFire && MP >= MPcost)
        {
            MP -= MPcost;
            nextFire = Time.time + fireRate_grenade;
            Instantiate(grenade, shotSpawn.position, shotSpawn.rotation);// as GameObject;
            //AudioSource se = GetComponent<AudioSource>();
            SE1.Play();
        }

        if (Input.GetKey(KeyCode.S) && Time.time > nextFire && SP >= SPcost)
        {
            SP -= SPcost;           
            SE1.Play();
        }
       
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
   
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * tilt);

    }

    private void OnTriggerStay(Collider other)
    {
        if (LayerMask.LayerToName(gameObject.layer)=="Damage"){
            return;
        }

  


        if (other.tag != "Boundary" && (other.tag == "Enemy" || other.tag == "Enemy_Bullet")){
            
            Debug.Log(player_current_hp);
            player_current_hp -= 1;

            if (player_current_hp <= 1.1f && player_current_hp >= 0.9f){
                SE3.Play();
            }

            hpSlider.value = player_current_hp; //Valueの値をPyHPの値にする
           


            if (player_current_hp <= 0){
                
                Instantiate(explosion, transform.position, transform.rotation);


                GameObject[] child = GameObject.FindGameObjectsWithTag("Child");
                for (int i = 0; i < child.Length; i++){
                    Instantiate(explosion, child[i].transform.position, child[i].transform.rotation);
                    Destroy(child[i].gameObject);
                }

                //switch (Parameter.STAGE)
                 //   {
                  //      case 1:
                   //         GameObject.FindWithTag("GameController").GetComponent<GameController_Stage1>().gameover(); 
                    //        break;
                     //   default:
                            GameObject.FindWithTag("GameController").GetComponent<GameController>().gameover();
                     //       break;
                   // }
           
             

                Destroy(gameObject);
      
            }else{
                SE2.Play();
                StartCoroutine("Damage");
            }

        
        }                  
    }

    IEnumerator Damage()
    {
        //レイヤーをPlayerDamageに変更
        gameObject.layer = LayerMask.NameToLayer("Damage");
        //while文を10回ループ
        int count = 20;
        while (count > 0)
        {
            //透明にする
            //GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0);
            GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
           
            //renderer.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            //GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
            //renderer.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            //yield return new WaitForSeconds(0.05f);
            count--;
        }
        //レイヤーをPlayerに戻す
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    public void RecoveryMP(float Recover){
        MP += Recover;
        if (MP >= mpSlider.maxValue){
            MP = mpSlider.maxValue;
        }
    }

    public void RecoverySP(float Recover)
    {
        SP += Recover;
        if (SP >= spSlider.maxValue)
        {
            SP = spSlider.maxValue;
        }
    }

}

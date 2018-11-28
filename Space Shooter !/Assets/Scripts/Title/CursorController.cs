using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{


    string next_state = "Continue";
    string current_state = "Continue";
    public Image select;
    AudioSource[] sources;
    public float moveWait = 3f;
    bool canMove = false;

    public Text NewGame;
    public Text Continue;

    // Use this for initialization
    void Start()
    {


        //NewGame = GetComponent<Text>();
        //Continue = GetComponent<Text>();

        //select = GameObject.Find("Image").GetComponent<Image>();
        sources = gameObject.GetComponents<AudioSource>();
        StartCoroutine(Wait());


        NewGame.color = new Vector4(255f, 255f, 255f, 255f);
        Continue.color = new Vector4(255f, 0f, 0f, 255f);

    }

    private void Update()
    {

        if (canMove){
            if (transform.position.y > 0.50f)
            {
                next_state = "New Game";
            }
            else
            {
                next_state = "Continue";
            }

            if (current_state != "New Game" && next_state == "New Game")
            {
                //select.rectTransform.position = new Vector3(select.rectTransform.position.x, -120.0f + 540f, select.rectTransform.position.z);
                Continue.color = new Vector4(255f, 255f, 255f, 255f);
                NewGame.color = new Vector4(255f, 0f, 0f, 255f);
                sources[0].Play();
            }
            else if (current_state != "Continue" && next_state == "Continue")
            {
                //select.rectTransform.position = new Vector3(select.rectTransform.position.x, -180.0f + 540f, select.rectTransform.position.z);
                NewGame.color = new Vector4(255f, 255f, 255f, 255f);
                Continue.color = new Vector4(255f, 0f, 0f, 255f);
                sources[0].Play();
            }
            current_state = next_state;


            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))
            {

                sources[2].Play();
                

                switch (current_state)
                {
                    case "New Game":

                        // データをロードせずに次のシーンへ
                        SceneManager.LoadScene("Stage Select");

                        break;
                    case "Continue":
                        
                        // データをロードして次のシーンへ



                        for (int i = 1; i <= 30; i++){
                            Parameter.HIGHSCORE[i] = Parameter.LoadHighScore(i);
                            Parameter.STAGE_CLEARED[i] = Parameter.LoadStageClear(i);
                        }                      
                        Parameter.CHILD = Parameter.LoadChild();
                      
                        if (Parameter.HIGHSCORE[1] == 0){
                            Debug.Log("セーブデータ破損可能性あり");
                        }

                        SceneManager.LoadScene("Stage Select");

                        break;
                }

                sources[0].pitch = 3.0f;

            }
        }
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (canMove){
            float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, moveVertical * 2, 0.0f);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = movement;

        this.transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -0.1f, 1.0f), transform.position.z);
    
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(moveWait);

        canMove = true;
        sources[1].Play();

    }
}


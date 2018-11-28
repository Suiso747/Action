using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class StageSelector : MonoBehaviour {
    
    public TextMeshProUGUI stageText;
    public GameObject backImage;
    string state;
    AudioSource[] sources;

    // 全てのステージの座標を格納
    public Transform[] stage_pos;


	// Use this for initialization
	void Start () {
        


        state = "SpaceColony";
        stageText = GetComponentInChildren<TextMeshProUGUI>();
        backImage = GameObject.Find("BackImage");
        sources = GetComponents<AudioSource>();
 

        sources[1].Play();
      
	}
	
	// Update is called once per frame
	void Update () {

        DisplayText();
        DisplayBackImage();

        // Stage1のとき、左でColony
        if (state == "Stage1" && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            state = "SpaceColony";
            sources[0].Play();
        }else if (state == "Stage1" && Input.GetKeyDown(KeyCode.UpArrow) && Parameter.STAGE_CLEARED[1] == 1)
        {
            state = "Stage2";
            sources[0].Play();
        }


        // Colonyのとき、右でStage1
        else if (state == "SpaceColony" && Input.GetKeyDown(KeyCode.RightArrow))
        {
            state = "Stage1";
            sources[0].Play();
        }

        // Stage2のとき、下でStage1
        else if (state == "Stage2" && Input.GetKeyDown(KeyCode.DownArrow))
        {
            state = "Stage1";
            sources[0].Play();
        }


        // 決定ボタンでシーンチェンジ
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))
        {

            sources[0].pitch = 3.0f;
            sources[0].Play();
            switch(state){
                
                case "SpaceColony":
                    SceneManager.LoadScene("City1");

                    break;

                case "Stage1":

              
                    SceneManager.LoadScene("Stage1");
                    break;

                case "Stage2":
               
                    SceneManager.LoadScene("Stage1");
                    break;
            }
           
        }


	}

    void DisplayText(){
        
        switch(state){
            case "Stage1":
                stageText.text = "Stage 1  " + "High Score: " + Parameter.HIGHSCORE[1] + "\n\n" +
                    "XXX light-years for our Xintiandi. We detected an extraordinary earth type planet." + "\n" +
                    "Unfortunately, as a result of atmospheric component analysis, it was filled with gas that is toxic to us," + "\n" +
                    "and even paradise of dangerous creatures. It is unlikely this planet will be a place of relief.";
                break;
            case "SpaceColony":
                stageText.text = "Space Colony";
                break;


            case "Stage2" :
                stageText.text = "Stage 2  " + "High Score: " + Parameter.HIGHSCORE[2] + "\n\n" +
                    "Ask Xintiand early XXXX light years. Detected an extraordinary earth type planet." + "\n" +
                    "Unfortunately, as a result of atmospheric component analysis, it was filled with gas that is toxic to us," + "\n" +
                    "and even paradise of dangerous creatures. It is unlikely this planet will be a place of relief.";
                break;
        }
    }

    void DisplayBackImage()
    {

        switch (state)
        {
            case "SpaceColony":
                backImage.transform.position = stage_pos[0].position;
                backImage.GetComponent<Image>().color = new Vector4(0, 0, 255, 255);        
                break;
            case "Stage1":
                backImage.transform.position = stage_pos[1].position;
                if (Parameter.STAGE_CLEARED[1] == 1)
                    backImage.GetComponent<Image>().color = new Vector4(0, 255, 0, 255);                
                else
                    backImage.GetComponent<Image>().color = new Vector4(255, 255, 0, 255);                
                break;
            case "Stage2":
                backImage.transform.position = stage_pos[2].position;
                if (Parameter.STAGE_CLEARED[2] == 1)
                    backImage.GetComponent<Image>().color = new Vector4(0, 255, 0, 255);                
                else
                    backImage.GetComponent<Image>().color = new Vector4(255, 255, 0, 255);   
                break;
        }
    }

   

}

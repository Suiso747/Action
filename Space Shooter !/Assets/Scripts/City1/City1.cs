using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class City1 : MonoBehaviour {

    public GameObject shopping;
    public GameObject equip;
    public GameObject save;
    public GameObject go;

    public int state;

	// Use this for initialization
	void Start () {
        state = 1;
 
        HighLight();
   

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            state = (state + 2) % 4 + 1;
            HighLight();
        }else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            state = state % 4 + 1;
            HighLight();
        }



        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)){

            switch(state){


                case 3:
                    // セーブする
                   
                    AllSave();
                    save.GetComponent<TextMeshProUGUI>().color = new Vector4(0.0f, 1.0f, 0.0f, 255f);
                    save.GetComponent<TextMeshProUGUI>().text = "SAVED!";
                    break;

                case 4:
                    SceneManager.LoadScene("Stage Select");
                    break;

            }


        }

	}

    void HighLight(){

        shopping.GetComponent<TextMeshProUGUI>().color = new Vector4(1.0f, 1.0f, 1.0f, 255f); 
        equip.GetComponent<TextMeshProUGUI>().color = new Vector4(1.0f, 1.0f, 1.0f, 255f); 
        save.GetComponent<TextMeshProUGUI>().color = new Vector4(1.0f, 1.0f, 1.0f, 255f); 
        go.GetComponent<TextMeshProUGUI>().color = new Vector4(1.0f, 1.0f, 1.0f, 255f); 
        save.GetComponent<TextMeshProUGUI>().text = "SAVE";

        switch(state){
            case 1:
                shopping.GetComponent<TextMeshProUGUI>().color = new Vector4(1.0f, 0.5f, 0.5f, 255f);
                break;
            case 2:
                equip.GetComponent<TextMeshProUGUI>().color = new Vector4(1.0f, 0.5f, 0.5f, 255f);
                break;
            case 3:
                save.GetComponent<TextMeshProUGUI>().color = new Vector4(1.0f, 0.5f, 0.5f, 255f);
                break;
            case 4:
                go.GetComponent<TextMeshProUGUI>().color = new Vector4(1.0f, 0.5f, 0.5f, 255f);
                break;
        }
       
     
    }

    void AllSave()
    {
        save.GetComponent<TextMeshProUGUI>().color = new Vector4(0.5f, 1.0f, 0.5f, 255f);
        save.GetComponent<TextMeshProUGUI>().text = "SAVING...!";

        Parameter.SaveChild(Parameter.CHILD);

        // ハイスコアとクリアフラグをセーブ
        for (int i = 1; i <= 30; i++)
        {
            Parameter.SaveHighScore(i, Parameter.HIGHSCORE[i]);
            Parameter.SaveStageClear(i, Parameter.STAGE_CLEARED[i]);
        }

    }
}

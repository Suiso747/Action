using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIにはこれが必要
using UnityEngine.SceneManagement;
using TMPro;



public class GameController : MonoBehaviour {

    public int STAGE_NUMBER = 1; 
    public GameObject scoreText;
    public GameObject highscoreText;
    public GameObject restartText;
    public GameObject gameoverText;
    public GameObject moneyText;

    private bool f_gameover;
    [HideInInspector] public bool f_restart;

    private int score;


    void Start(){

        f_gameover = false;
        f_restart = false;
        restartText.GetComponent<Text>().text = "";
        gameoverText.GetComponent<Text>().text = "";

        Parameter.SCORE = score;

        UpdateScore();
    

    }

    private void Update()
    {
        Parameter.SCORE = score;

        TextMeshProUGUI tmPro = moneyText.GetComponent<TextMeshProUGUI>();
        int current_money = Parameter.MONEY + Parameter.STAGE_MONEY;
        tmPro.text = "[$]MONEY : " + current_money;


        if (f_gameover)
        {
            restartText.GetComponent<Text>().text = "Press [C]:Continue [T]:Title";
            f_restart = true;
        }


        if (f_restart){
            if (Input.GetKeyDown(KeyCode.C)){
                // Application.LoadLevel(Application.loadedLevel);
                Parameter.STAGE_MONEY = 0;
                SceneManager.LoadScene("Stage"+STAGE_NUMBER);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                // Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Title");
            }
        }
    }

   

    public void AddScore (int newScoreValue){
        score += newScoreValue;
        UpdateScore();
    }
	
	// Update is called once per frame
	public void UpdateScore () {



        TextMeshProUGUI tmPro = scoreText.GetComponent<TextMeshProUGUI>();
        tmPro.text = "SCORE : " + score;

        tmPro = moneyText.GetComponent<TextMeshProUGUI>();
        int current_money = Parameter.MONEY + Parameter.STAGE_MONEY;
        tmPro.text = "[$]MONEY : " + current_money;


        tmPro = highscoreText.GetComponent<TextMeshProUGUI>();
        if (score >= Parameter.HIGHSCORE[STAGE_NUMBER])
        {
            tmPro.text = "HIGHSCORE : " + score;
        }else{           
            tmPro.text = "HIGHSCORE : " + Parameter.HIGHSCORE[STAGE_NUMBER];
        }
       
        //scoreText.GetComponent<Text>().text = "SCORE : " + score;


	}

    public void StageClear()
    {

        Parameter.MONEY += Parameter.STAGE_MONEY;

        Parameter.SCORE = score;
        if (score >= Parameter.HIGHSCORE[STAGE_NUMBER]){
            Parameter.HIGHSCORE[STAGE_NUMBER] = score;
        }
        Parameter.STAGE_CLEARED[STAGE_NUMBER] = 1;
        SceneManager.LoadScene("Stage Select");

      

    }

    public void gameover(){
        gameoverText.GetComponent<Text>().text = "Game Over";
        f_gameover = true;
    }
}

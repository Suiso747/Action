/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIにはこれが必要
using UnityEngine.SceneManagement;
using TMPro;// TextMeshProにはこれが必要
*/

/*
 *   このスクリプトは”ステージ１”
 */

/*
public class GameController_Stage1 : MonoBehaviour
{

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public int finalhazardN;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GameObject scoreText;
    public GameObject restartText;
    public GameObject gameoverText;

    private bool f_gameover;
    private bool f_restart;

    private int score;

    void Start()
    {


        f_gameover = false;
        f_restart = false;
        restartText.GetComponent<Text>().text = "";
        gameoverText.GetComponent<Text>().text = "";

        score = Parameter.exp;
        //AddScore(Parameter.exp);

        UpdateScore();
        StartCoroutine(SpawnWaves());

    }

    private void Update()
    {
        if (f_gameover)
        {
            restartText.GetComponent<Text>().text = "Press [C]:Continue [T]:Title";
            f_restart = true;
        }


        if (f_restart)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                // Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Stage1");
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                // Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Title");
            }
        }
    }

    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);

        while (true && !f_restart)
        {
            hazardCount += 1;

            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);


                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);


            if (hazardCount >= finalhazardN){
                StageClear();
            }

        }

    }


    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    // Update is called once per frame
    void UpdateScore()
    {
        TextMeshProUGUI tmPro = scoreText.GetComponent<TextMeshProUGUI>();
        tmPro.text = "SCORE : " + score;
        //material.SetColor("_OutlineColor", Color.red); //縁取り色を赤色に変える

        //scoreText.GetComponent<TextMesh>().text = "経験値: " + score;

    }

    public void gameover()
    {
        gameoverText.GetComponent<Text>().text = "Game Over";
        f_gameover = true;
    }

    public void StageClear(){

        Parameter.exp = score;
        Parameter.STAGE1_CLEARED = 1;
        SceneManager.LoadScene("Stage Select");


    }
}
*/
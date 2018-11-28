
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeParameter : MonoBehaviour {
    
    public int[] IS_STAGE_CLEARED = new int[10];
    public int SCORE;
    public int[] STAGE_HIGHSCORE = new int[10];
    public int CHILD;

	// Use this for initialization
	void Start () {
        

        for (int i = 1; i <= 5; i++){
            IS_STAGE_CLEARED[i] = Parameter.STAGE_CLEARED[i];
            STAGE_HIGHSCORE[i] = Parameter.HIGHSCORE[i];
        }


      

        SCORE = Parameter.SCORE;
        CHILD = Parameter.CHILD;


        StartCoroutine(FuncCoroutine());
	}
	
   
    IEnumerator FuncCoroutine()
    {
        while (true)
        {

            for (int i = 1; i <= 5; i++)
            {
                IS_STAGE_CLEARED[i] = Parameter.STAGE_CLEARED[i];
                STAGE_HIGHSCORE[i] = Parameter.HIGHSCORE[i];
            }

            SCORE = Parameter.SCORE;
            CHILD = Parameter.CHILD;


            yield return new WaitForSeconds(1);
        }
    }


}

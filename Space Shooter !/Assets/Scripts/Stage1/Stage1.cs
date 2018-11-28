using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour {

    

	public GameObject[] hazards;
    public Vector3 spawnValues;
	public int hazardCount;
	public int finalhazardN;
    public float spawnWait;
    public float startWait;
    public float waveWait;

	public GameController GC;

	// Use this for initialization
	void Start () {

        // お金リセット
        Parameter.STAGE_MONEY = 0;

		GameController GC = GetComponent<GameController>();
		StartCoroutine(SpawnWaves());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnWaves()
	{

        yield return new WaitForSeconds(startWait);

        while(true && !GC.f_restart){
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

            if (hazardCount >= finalhazardN && !GC.f_restart){
                GC.StageClear();
            }


        }
      
    }


}

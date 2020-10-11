using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*NOTICE!
 Spawn interval did not work alongside InvokeRepeating() alone. 
 CancelInvoke() and Invoke() therefore creates another loop to compensate
 for this error*/

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        //Cancels InvokeRepeating after execution, cancels sequentially-run invokes after complete execution
        CancelInvoke();
        
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        int ballLength = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballLength], spawnPos, ballPrefabs[ballLength].transform.rotation);
        
        //Change spawn interval to 3-5 seconds and re-Invokes the method.
        spawnInterval = Random.Range(3.0f, 5.0f);
        Invoke("SpawnRandomBall", spawnInterval);
    }
}

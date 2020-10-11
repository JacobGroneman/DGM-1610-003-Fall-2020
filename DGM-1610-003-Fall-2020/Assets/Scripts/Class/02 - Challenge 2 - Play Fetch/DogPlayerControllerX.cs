using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DogPlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public bool spawnIsWait = false; 

    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0f && spawnIsWait == false)
        {
            spawnIsWait = true;
            StartCoroutine(SendDog());
        }
    }

    //Prevents spawning multiple dogs
    IEnumerator SendDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(2f);
        spawnIsWait = false;
    }
}

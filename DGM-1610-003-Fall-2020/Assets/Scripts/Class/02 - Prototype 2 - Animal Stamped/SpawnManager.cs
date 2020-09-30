using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] AnimalPrefabs;
    private int _animalIndex;

    void Update()
    {
        #region Input
            if (Input.GetKeyDown(KeyCode.S))
            {
                //Spawns Animals Randomly (transform.position.x = -20 through 20)
                    _animalIndex = Random.Range(0, AnimalPrefabs.Length);
                        Instantiate
                            (AnimalPrefabs[_animalIndex], new Vector3(Random.Range(-20, 20), 0, 29.97f),
                            AnimalPrefabs[_animalIndex].transform.rotation);
            }
            #endregion
    }
}

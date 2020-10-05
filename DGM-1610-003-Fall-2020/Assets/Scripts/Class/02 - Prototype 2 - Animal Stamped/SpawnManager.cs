using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] AnimalPrefabs;
    private int _animalIndex;

    private float
        _startDelay = 2f,
        _spawnInterval = 1f;

    void Start()
    {
        #region Initialization
            InvokeRepeating("SpawnRandomAnimals", _startDelay, _spawnInterval);
            #endregion
    }
    
    #region Methods
        void SpawnRandomAnimals()
        {
            //Spawns Animals Randomly (transform.position.x = -20 through 20)
                _animalIndex = Random.Range(0, AnimalPrefabs.Length);
                Instantiate
                (AnimalPrefabs[_animalIndex], new Vector3(Random.Range(-20, 20), 0, 29.97f),
                    AnimalPrefabs[_animalIndex].transform.rotation);
        }
            #endregion
}

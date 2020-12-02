using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeSpawnProgression : MonoBehaviour
{
    public int AlienCount;
    private float _spawnRange = 100;
    public int SpawnNumberAlien = 1;
    public GameObject AlienPrefab;

    void Start()
    {
        StartSpawn(SpawnNumberAlien, AlienPrefab);
    }

    void Update()
    {
        AlienCount = FindObjectsOfType<PracticeAlien>().Length;
        if (AlienCount == 0)
        {
            SpawnNumberAlien++;
            StartSpawn(SpawnNumberAlien, AlienPrefab);
        }
    }

    #region Spawn
    //Generates a Random Spawn Position
        private Vector3 _spawnPositionRandom()
        {
            float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
            float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
            Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
                
            return randomPos;
        }
    //Spawns Creatures
        private void StartSpawn(int spawnAmount, GameObject creatureToSpawn)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                Instantiate
                    (creatureToSpawn, _spawnPositionRandom(), AlienPrefab.transform.rotation);
            }
        }
        #endregion
}

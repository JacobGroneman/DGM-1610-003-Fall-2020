using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4SpawnManager : MonoBehaviour
{
    private float _spawnRange = 9.0f;
    public int EnemyCount;
    public int spawnWaveNumber = 1;

    public GameObject EnemyPrefab;
    public GameObject PowerupPrefab;

    void Start()
    {
        #region Placement
            Instantiate
                (PowerupPrefab, GenerateRandomSpawnPosition(), 
                PowerupPrefab.transform.rotation);
            SpawnEnemyWave(spawnWaveNumber);
            #endregion
    }

    void Update()
    {
        #region Instantiation
        //1++ Enemies and Adds Power-up to Every Spawn
            EnemyCount = FindObjectsOfType<U4Enemy>().Length;
            if (EnemyCount == 0)
            {
                Instantiate
                    (PowerupPrefab, GenerateRandomSpawnPosition(),
                    PowerupPrefab.transform.rotation);
                spawnWaveNumber++;
                SpawnEnemyWave(spawnWaveNumber);
            }
            #endregion
    }
    
    #region Spawning
        private Vector3 GenerateRandomSpawnPosition()
        {//Generates a Random Spawn Position
            float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
            float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
            Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
            
            return randomPos;
        }
        private void SpawnEnemyWave(int enemiesToSpawn)
        {//Spawns Enemies Based on spawnWaveNumber
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate //Enemy
                (EnemyPrefab, GenerateRandomSpawnPosition(), 
                    EnemyPrefab.transform.rotation);
            }
        }
        #endregion
}

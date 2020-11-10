using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4SpawnManager : MonoBehaviour
{
    private float _spawnRange = 9.0f;
    
    public GameObject EnemyPrefab;

    void Start()
    {
        #region Instantiation
            Instantiate //Enemy
                (EnemyPrefab, GenerateRandomSpawnPosition(), 
                EnemyPrefab.transform.rotation);
                #endregion
    }
    
    private Vector3 GenerateRandomSpawnPosition()
    {//Generates a Random Spawn Position
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        
        return randomPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit3SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 _spawnPos = new Vector3(25, 0, 0);
    private float _startDelay, _repeatDelay;
    private Unit3PlayerController _playerController;
    
    void Start()
    {
        InvokeRepeating("SpawnObstacles", _startDelay, _repeatDelay);
        _playerController = GameObject.Find("Player").GetComponent<Unit3PlayerController>();
    }
    
    void SpawnObstacles()
    {
        if (_playerController.gameOver == false)
        {
            Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
        }
        else
        {
            CancelInvoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    private GameObject[] _gameObjects;

    void Start()
    {
        #region Assignment
                _gameObjects = GameObject.FindGameObjectsWithTag("objs");
                #endregion
    }
    
    void Update()
    {
        #region Input
            //Space-bar Positions _gameObjects[] Randomly
                var randomValue = Random.Range(-100, 100);
                if (!Input.GetKeyDown(KeyCode.Space)) return;
                foreach (var obj in _gameObjects)
                {
                    obj.transform.position = new Vector3
                        (randomValue, randomValue, randomValue);
                }
                #endregion
    }
}

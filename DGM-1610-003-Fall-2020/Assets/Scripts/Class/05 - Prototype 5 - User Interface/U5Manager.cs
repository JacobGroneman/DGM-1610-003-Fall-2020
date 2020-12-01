using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class U5Manager : MonoBehaviour
{
    public List<GameObject> Targets;

    private float _spawnInterval = 1.0f;

    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);
            
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);
            
            //yield break;
        }
    }
}

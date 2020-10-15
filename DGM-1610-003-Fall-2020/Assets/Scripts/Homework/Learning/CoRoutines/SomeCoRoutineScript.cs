using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script simulates the scanning radio bands from 0Hz to 3,000GHz,
//starting from a random frequency and raising .10Hz every half-second
//until 3,000GHz.

public class SomeCoRoutineScript : MonoBehaviour
{
    private float _frequency, _randomFrequency;

    void Start()
    {
        _randomFrequency = Random.Range(0f, 3000000000000f);
        StartCoroutine(FrequencyScan());
    }

    private IEnumerator FrequencyScan()
    {
        do
        {
            _frequency += .10f;
            yield return new WaitForSeconds(0.5f);
        } while (_frequency < 3000000000000f);
    }
}

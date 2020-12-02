using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeScriptReferencer : MonoBehaviour
{
    private PracticeScriptAuthor _speedScript;

    void Update()
    {
        _speedScript.velocity = transform.position.magnitude / Time.deltaTime;

        if (_speedScript.velocity == 0)
        {
            Debug.Log("Throttle It!");
        }
        else if(_speedScript.velocity >= 100)
        {
            Debug.Log("Slow It, Buster!");
        }
    }
}

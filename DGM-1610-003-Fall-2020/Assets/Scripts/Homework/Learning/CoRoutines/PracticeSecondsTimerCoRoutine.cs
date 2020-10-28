using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Finish the Reset and the Stop Timer Later!
public class PracticeSecondsTimerCoRoutine : MonoBehaviour
{ 
    private bool _timerIsStarted = false;
    private int _minutesSet = 0;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (_timerIsStarted == false)
            {
                _minutesSet = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (_timerIsStarted == false)
            {
                _minutesSet = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (_timerIsStarted == false)
            {
                _minutesSet = 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            _timerIsStarted = true;
            StartCoroutine(StartTimer(_minutesSet));
        }
        
        Debug.Log("Minutes Left: " + _minutesSet);
    }

    IEnumerator StartTimer(int minutes)
    {
        for (int i = minutes; i > 0; i--)
        {
            yield return new WaitForSeconds(60.0f);
            minutes--;
            _minutesSet = minutes;
        }
    }
}

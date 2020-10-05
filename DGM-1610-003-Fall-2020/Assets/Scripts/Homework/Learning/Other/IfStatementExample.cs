using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfStatementExample : MonoBehaviour
{
    private int _randomNumber;
    Color _resultColor;

    void Start()
    {
        _resultColor = Color.clear;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _randomNumber = Random.Range(1, 10);
            GenerateRandomizedResult(_randomNumber, _resultColor);
        }
    }

    private static void GenerateRandomizedResult(int number, Color color)
    {
        if (number < 5)
        {
            color = Color.red;
        }
        else if(number == 5)
        {
            color = Color.yellow;
        }
        else if (number > 5)
        {
            color = Color.green;
        }
    }
}

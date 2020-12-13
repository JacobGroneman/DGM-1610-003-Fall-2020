using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PracticeTrafficSwitch : MonoBehaviour
{
    private GameObject _trafficLight;
    
    private int _colorIndex = 0;

    void Start()
    {
        _trafficLight.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _colorIndex >= 0)
        {
            _colorIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && _colorIndex <= 2)
        {
            _colorIndex++;
        }
        
        Traffic();
    }

    void Traffic()
    {
        Color trafficColor = _trafficLight.GetComponent<MeshRenderer>().material.color;

        switch (_colorIndex)
        {
            case 0:
                trafficColor = Color.red;
                break;
            case 1:
                trafficColor = Color.yellow;
                break;
            case 2:
                trafficColor = Color.green;
                break;
        }
    }
}

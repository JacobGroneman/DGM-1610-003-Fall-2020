using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticePhysics : MonoBehaviour
{
    private int _physicsIndex;
    
    void Start()
    {
        _physicsIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _physicsIndex > 0)
        {
            _physicsIndex++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && _physicsIndex < 7)
        {
            _physicsIndex--;
        }
        
        Physics();
    }

    void Physics()
    {
        switch (_physicsIndex)
        {
            case 0:
                const float gravityModAmount = 5f;
                var gravity = UnityEngine.Physics.gravity;
                gravity.x = gravityModAmount;
                break;
            case 2:
                UnityEngine.Physics.autoSimulation = true;
                break;
            case 3:
                UnityEngine.Physics.bounceThreshold = 55;
                break;
            case 4:
                var _layers = UnityEngine.Physics.AllLayers;
                _layers = _physicsIndex;
                break;
            case 5:
                const float step = 5;
                UnityEngine.Physics.Simulate(step);
                break;
            case 6:
                UnityEngine.Physics.SphereCast(
                    new Ray(transform.position, Vector3.forward),
                    5f); //Research this one
                break;
        }
    }
}

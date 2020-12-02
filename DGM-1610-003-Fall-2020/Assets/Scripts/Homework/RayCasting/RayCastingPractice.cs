using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script Was Researched from Unity's Scripting API :)

public class RayCastingPractice : MonoBehaviour
{
    void FixedUpdate()
    {
        int layerMask = 1 << 8; //Research Bit Shifting!!!
        layerMask = ~layerMask; //Inverts Layermask (Raycasts Everything but LayerMask(8))
        
        RaycastHit hit;
        if (Physics.Raycast(
            transform.position, 
            transform.TransformDirection(Vector3.forward), out hit, 
            Mathf.Infinity, layerMask))
        {
            Debug.DrawRay
                (transform.position, 
                transform.TransformDirection(Vector3.forward) 
                * hit.distance, Color.green);
            Debug.Log("Raycast Hit: " + hit.point);
        }
        else
        {
            Debug.DrawRay
                (transform.position, 
                transform.TransformDirection(Vector3.forward) 
                * 1000, Color.red);
            Debug.Log("Raycast Fail: " + hit.point);
        }
    }
}

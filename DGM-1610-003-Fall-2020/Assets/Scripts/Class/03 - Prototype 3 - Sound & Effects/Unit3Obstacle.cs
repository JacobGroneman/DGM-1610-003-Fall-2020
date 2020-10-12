using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit3Obstacle : MonoBehaviour
{
    public float velocity;
    
    void FixedUpdate()
    {
        transform.Translate
            (Vector3.left * velocity * Time.deltaTime);
    }
}

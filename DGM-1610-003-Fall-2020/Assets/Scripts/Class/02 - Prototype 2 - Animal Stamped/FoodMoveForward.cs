using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMoveForward : MonoBehaviour
{
    public float velocity = 40f;
    
    void Update()
    {
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}

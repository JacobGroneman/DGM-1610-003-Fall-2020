using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : MonoBehaviour
{
    public int velocity = 20;
    
    void Start()
    {
        
    }

    void Update()
    {
        //Control Forward
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}

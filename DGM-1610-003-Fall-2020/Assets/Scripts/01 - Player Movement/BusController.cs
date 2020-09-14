using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : MonoBehaviour
{
    public int velocity = 0;
    public float turnSpeed = 0;
    
    public float HorizontalInput;
    public float VerticalInput;

    void Start()
    {
        
    }

    void Update()
    {
        //Control Button Mechanics
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        
        //Control Forward
        transform.Translate(Vector3.forward * velocity * VerticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * turnSpeed * HorizontalInput * Time.deltaTime);
    }
}

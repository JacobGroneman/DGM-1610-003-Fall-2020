using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : MonoBehaviour
{
    private int velocity = 20;
    private float turnSpeed = 100;
    
    private float HorizontalInput;
    private float VerticalInput;
    
    void Update()
    {
        //Control Button Mechanics
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        
        
        //Control Forward by Vertical Input
        transform.Translate(Vector3.forward * velocity * VerticalInput * Time.deltaTime);
        //Control Rotate by Horizontal Input
        transform.Rotate(Vector3.up * turnSpeed * HorizontalInput * Time.deltaTime);
    }
}

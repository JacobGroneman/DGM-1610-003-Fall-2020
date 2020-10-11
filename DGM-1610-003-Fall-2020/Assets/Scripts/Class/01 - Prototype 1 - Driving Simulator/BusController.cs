using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : MonoBehaviour
{
    private int velocity = 20;
    private float turnSpeed = 100f;
    
    private float _horizontalInput;
    private float _verticalInput;
    
    void Update()
    {
        //Control Button Mechanics
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        
        //Control Forward by Vertical Input
        transform.Translate(Vector3.forward * velocity * _verticalInput * Time.deltaTime);
        //Control Rotate by Horizontal Input
        transform.Rotate(Vector3.up * turnSpeed * _horizontalInput * Time.deltaTime);
    }
}

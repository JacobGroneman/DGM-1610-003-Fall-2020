using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX1 : MonoBehaviour
{
    private float _speed = 15f;
    private float _rotationSpeed = 100f;
    
    private float _verticalInput;
    
    void FixedUpdate()
    {
        #region Physics
            //Plane's Speed Constant
                transform.Translate(Vector3.forward * _speed * Time.deltaTime);
                #endregion
                
        #region Input
            //Input Pitch & Yaw (Up and Down)
                _verticalInput = Input.GetAxis("Vertical"); 
            //Plane Tilt
                transform.Rotate(Vector3.right * _rotationSpeed * _verticalInput * Time.deltaTime);
                #endregion
    }
}

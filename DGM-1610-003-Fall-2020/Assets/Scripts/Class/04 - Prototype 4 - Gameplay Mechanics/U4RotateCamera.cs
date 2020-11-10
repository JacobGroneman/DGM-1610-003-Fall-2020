using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4RotateCamera : MonoBehaviour
{
    private float _rotationalVelocity = 100.0f;
    
    void Update()
    {
        #region Input
        //Rotates Camera
            float inputHorizontal = Input.GetAxis("Horizontal");
            var rotateParameters = inputHorizontal * _rotationalVelocity * Time.deltaTime;
            transform.Rotate(Vector3.up, rotateParameters);
            #endregion
    }
}

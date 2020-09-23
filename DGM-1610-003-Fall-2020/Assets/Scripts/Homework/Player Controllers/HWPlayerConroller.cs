using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HWPlayerController : MonoBehaviour
{
    private float _velocity;
    private float _horizontalInput, _verticalInput;
    
    void Update()
    {
        #region Input
        //Horizontal Input
            _horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate
                (Vector3.right * _horizontalInput * _velocity * Time.deltaTime);
        //Vertical Input
            _verticalInput = Input.GetAxis("Vertical");
            transform.Translate
                (Vector3.up *_verticalInput *_velocity * Time.deltaTime);
        #endregion
    }
}
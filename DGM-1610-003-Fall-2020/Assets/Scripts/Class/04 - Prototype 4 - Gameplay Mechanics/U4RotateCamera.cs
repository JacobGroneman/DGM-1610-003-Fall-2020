using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4RotateCamera : MonoBehaviour
{
    
    public float rotationalVelocity = 50f;

    void Update()
    {
        #region Input
        //Rotates camera around the Y axis
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationalVelocity * Time.deltaTime);
            #endregion
    }
}

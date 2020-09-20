using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerMovement : MonoBehaviour
{
    private float turnSpeed = 500f;
    
    void Update()
    {
        #region Physics
            //Rotates the Propeller
                transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);
                #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float forwardVelocity;
    public float rotationalVelocity;
    
    void Update()
    {
        #region Input
                        //Replace -vertical With a Reverse Mechanism
        //Forward
            float translation = Input.GetAxis("Vertical");
            float translationParameters = translation * forwardVelocity * Time.deltaTime;
            transform.Translate(Vector3.forward * translationParameters);
        //Left/Right
            float rotation = Input.GetAxis("Horizontal");
            float rotationParameters = rotation * forwardVelocity * Time.deltaTime;
            transform.Rotate(Vector3.up * rotationParameters);
        #endregion
    }
}

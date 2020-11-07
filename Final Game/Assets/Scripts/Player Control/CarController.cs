using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float forwardVelocity;
    public float rotationalVelocity;

    public bool _isGrounded;
    
    void Update()
    {
        #region Input
                        //Replace -vertical With a Reverse Mechanism
        //Forward
            float inputVertical = Input.GetAxis("Vertical");
            float translationParameters = inputVertical * forwardVelocity * Time.deltaTime;
            transform.Translate(Vector3.forward * translationParameters);
        //Left/Right
            float inputHorizontal = Input.GetAxis("Horizontal");
            float rotationParameters = inputHorizontal * rotationalVelocity * Time.deltaTime;
            transform.Rotate(Vector3.up * rotationParameters);
            #endregion
            
        #region Physical Parameters
        //Car velocities relational to physical ground
        // *See OnCollisionEnter
            if (!_isGrounded) 
            { 
                forwardVelocity = 0f; 
                rotationalVelocity = 0f;
            }
            else if (_isGrounded)
            {
                forwardVelocity = 150f; 
                rotationalVelocity = 100f;
            }
            #endregion
    }

    #region Unity Methods
        void OnCollisionEnter(Collision other)
        {
            //Terrain Collisions
            if (other.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }
        #endregion
}

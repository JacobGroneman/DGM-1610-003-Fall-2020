using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Referencing Unity's Scripting API
/*(Needs a Nav Mesh, Turning effects, Accelerate/Decelerate,*/  
public class PlayerController : MonoBehaviour
{
    public Camera _playerCamera;
    
    public float _velocity = 110;
    public float _rotationalVelocity = 150;

    public bool isGrounded = true;
    
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * _velocity;
        float rotation = Input.GetAxis("Horizontal") * _rotationalVelocity;
        
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        if (isGrounded == true)
        {
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
        else
        {
            transform.Translate(Vector3.zero);
            transform.Rotate(Vector3.zero);
        }
    }
}

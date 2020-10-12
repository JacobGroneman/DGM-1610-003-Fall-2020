using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player is Floating
public class Unit3PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public int _jumpPower = 6;
    public float _gravity = -9.8f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravity;
    }

    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }
}

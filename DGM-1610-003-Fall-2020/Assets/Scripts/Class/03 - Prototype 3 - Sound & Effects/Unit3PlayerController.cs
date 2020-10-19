using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player is Floating
public class Unit3PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public int _jumpPower = 6;
    public float _gravity = -9.8f;

    private bool _isGrounded = true;
    public bool gameOver = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravity;
    }

    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _isGrounded = false;
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collider other)
    {
        _isGrounded = true;

        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("GAME OVER");
            Time.timeScale = 0;
        }
    }
}

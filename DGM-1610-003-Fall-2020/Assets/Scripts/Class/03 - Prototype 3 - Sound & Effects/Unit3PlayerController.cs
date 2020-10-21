using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player is Floating
public class Unit3PlayerController : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody _rb;
    public int _jumpPower = 6;
    public float _gravity = 9.8f;

    private bool _isGrounded = true;
    public bool gameOver = false;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravity;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _isGrounded = false;
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _anim.SetTrigger("Jump_trig");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("GAME OVER");
            _anim.SetBool("Death_b", true);
            _anim.SetInteger("DeathType_int", 1);
        }
    }
}

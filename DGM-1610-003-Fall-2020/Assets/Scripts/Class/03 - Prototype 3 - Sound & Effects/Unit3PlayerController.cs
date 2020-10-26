using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player is Floating
public class Unit3PlayerController : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody _rb;

    public ParticleSystem dirt;
    public ParticleSystem explosion;
    
    //Audio (SFx)
    public AudioClip audioJump, audioCollide;
    public AudioSource playerAudio;
    
    public int _jumpPower = 6;
    public float _gravity = 9.8f;

    private bool _isGrounded = true;
    public bool gameOver = false;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravity;

        playerAudio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true && gameOver == false)
        {
            _isGrounded = false;
            playerAudio.PlayOneShot(audioJump, 1f);
            dirt.Stop();
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _anim.SetTrigger("Jump_trig");
        }

        if (gameOver == true)
        {
            dirt.Stop();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            dirt.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAudio.PlayOneShot(audioCollide, 1.0f);
            Debug.Log("GAME OVER");
            explosion.Play();
            _anim.SetBool("Death_b", true);
            _anim.SetInteger("DeathType_int", 1);
            dirt.Stop();
        }
    }
}

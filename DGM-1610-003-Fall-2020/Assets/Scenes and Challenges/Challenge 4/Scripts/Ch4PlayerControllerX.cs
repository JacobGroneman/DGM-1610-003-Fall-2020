﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch4PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float defaultSpeed = 50f;
    private float speed = 500f;
    private float boostSpeed = 1000f;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    private ParticleSystem _powerUpParticle;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        _powerUpParticle = GameObject.Find("Smoke_Particle").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

        //Speed Boost!
        if (Input.GetKey(KeyCode.Space))
        {
            SpeedBoost();
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            speed = defaultSpeed;
        }
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 vectorEnemy =  other.gameObject.transform.position - transform.position;
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(vectorEnemy * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(vectorEnemy * normalStrength, ForceMode.Impulse);
            }
        }
    }

    private void SpeedBoost()
    {
        _powerUpParticle.Play();
        speed = boostSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4PlayerController : MonoBehaviour
{
    public float _velocity = 5.0f;

    private Rigidbody _rb;

    private GameObject _focalPoint;
    public GameObject powerupIndicator;
    
    // Power-ups
        private bool _hasPowerup = false;
        private float _powerupStrength = 15.0f;
    
    void Start()
    {
        #region Assignment
            _rb = GetComponent<Rigidbody>();
            _focalPoint = GameObject.Find("FocalPoint");
            #endregion
    }

    void Update()
    {
        #region Input
        //Moves Player Forward Based on Focal Point
            float inputForward = Input.GetAxis("Vertical");
            var forceParameters = inputForward * _velocity;
            _rb.AddForce(_focalPoint.transform.forward * forceParameters);
            #endregion

        #region Placement
        //Places Power-up Indicator Below Player                
            powerupIndicator.transform.position = 
            transform.position + new Vector3(0, -0.5f, 0);
            #endregion
    }

    #region Collider
    //Power-up Attainment and Countdown
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Powerup"))
            {
                _hasPowerup = true;
                Destroy(other.gameObject);
                powerupIndicator.gameObject.SetActive(true);
                StartCoroutine(PowerupCountdown());
            }
        }
    //Makes Enemies Fly after Player Attains Power-up
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && _hasPowerup)
            { 
                /*Debug.Log("Player Collision: " + collision.gameObject
                 + ". HasPowerUp =  " + _hasPowerup);*/
                
                Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 vectorCollision = collision.gameObject.transform.position - transform.position;
                
                enemyRb.AddForce(vectorCollision * _powerupStrength, ForceMode.Impulse);
            }
        }
    #endregion

    #region Routine
        IEnumerator PowerupCountdown()
        {
            yield return new WaitForSeconds(7);
            _hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }
        #endregion
}

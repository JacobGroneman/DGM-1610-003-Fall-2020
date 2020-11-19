using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeAlien : MonoBehaviour
{
    private ParticleSystem _smokeParticle;
    
    private AudioSource _audioSource;
    private AudioClip _squeal;
    private AudioClip _yell;

    void Start()
    {
        #region Assignment
            _smokeParticle = GameObject.Find("SmokeParticle")
                .GetComponent<ParticleSystem>();
    
            _audioSource = GetComponent<AudioSource>();
            _squeal = GetComponent<AudioSource>().clip;
            #endregion
    }

    #region Collisions
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Laser"))
            {
                //Smoke Particle
                _smokeParticle.gameObject.transform.position 
                    = this.transform.position;
                other.gameObject.GetComponent<ParticleSystem>().Play();
                //"I'm Dying!"
                _yell = GetComponent<AudioSource>().clip;
                _audioSource.Play();
                //Bye-Bye!
                Destroy(other.gameObject);
            }
        }
        #endregion
}

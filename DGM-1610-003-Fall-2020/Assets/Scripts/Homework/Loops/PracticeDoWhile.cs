using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PracticeDoWhile : MonoBehaviour
{
    private int _points;
    private bool _isGrounded = true;
    public AudioSource GroundedAudio, AirbourneAudio;
    
    void Update()
    {
        do
        {
            _points++;
        } while (_isGrounded == true);
        do
        {
            _points--;
        } while (_isGrounded == false);
        

        if (_isGrounded == true)
        {
            AirbourneAudio.mute = true;
            GroundedAudio.mute = false;
            GroundedAudio.Play();
        }
        else if (_isGrounded == false)
        {
            GroundedAudio.mute = true;
            AirbourneAudio.mute = false;
            AirbourneAudio.Play();
        }
    }
}

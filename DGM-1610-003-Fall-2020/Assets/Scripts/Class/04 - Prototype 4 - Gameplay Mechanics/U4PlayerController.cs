using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4PlayerController : MonoBehaviour
{
    public float _velocity = 5.0f;

    private Rigidbody _rb;

    private GameObject _focalPoint;
    
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
    }
}

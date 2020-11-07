using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial From: https://www.youtube.com/watch?v=cqATTzJmFDY (15:37)
public class TutorialScript : MonoBehaviour
{
    public Rigidbody rb;

    public float
        maxVelocity = 50f, rotationalForce = 180f,
        forwardAccel = 8f, reverseAccel = 4f;

    private float
        _inputVelocity, _inputRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.transform.parent = null; //<- Un-parents Object
        
        rb.interpolation = RigidbodyInterpolation.Extrapolate; //<- Smooths Car Movement
    }

    void Update()
    {
        var forceParameters = forwardAccel * (1000/*Time Value*/);
        var reverseForceParameters = reverseAccel * (1000/*Time Value*/);

        _inputVelocity = 0f;
        if (Input.GetAxis("Vertical") > 0)
        {
            _inputVelocity = Input.GetAxis("Vertical") * forceParameters;
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            _inputVelocity = Input.GetAxis("Vertical") * reverseForceParameters;
        }

        _inputRotation = Input.GetAxis("Horizontal");
        var rotationParameters = _inputRotation * rotationalForce * Time.deltaTime;
        
        transform.rotation = Quaternion.Euler
            (transform.rotation.eulerAngles + 
             new Vector3(0f, rotationParameters, 0f));
        transform.position = rb.transform.position;
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(_inputVelocity) > 0)
        {
            rb.AddForce(transform.forward * _inputVelocity);
        }
        //var forceParameters = forwardAccel * (1000/*Time Value*/);
        //rb.AddForce(transform.position * forceParameters);
    }
}

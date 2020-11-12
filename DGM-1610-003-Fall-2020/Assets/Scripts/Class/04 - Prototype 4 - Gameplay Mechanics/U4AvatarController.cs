using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4AvatarController : MonoBehaviour
{
    private float _velocity = 25f;

    private Rigidbody _rigidBody;
    
    private GameObject _worldFocalPoint;
    
    void Start()
    {
        #region Assignment
            _rigidBody = GetComponent<Rigidbody>();
            _worldFocalPoint = GameObject.Find("World Focal Point");
            #endregion
    }

    
    void Update()
    {
        #region Input
        //Translates Avatar Forward Based on the Vertical Input Axis
            float inputForward = Input.GetAxisRaw("Vertical");
            _rigidBody.AddForce(_worldFocalPoint.transform.forward * inputForward * _velocity);
            #endregion
    }
}

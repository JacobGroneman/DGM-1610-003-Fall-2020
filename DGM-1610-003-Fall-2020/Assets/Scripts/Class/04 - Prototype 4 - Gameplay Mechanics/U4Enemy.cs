using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4Enemy : MonoBehaviour
{
    public float _velocity = 10f;
    
    private Rigidbody _rigidbody;

    private GameObject _avatar;
    
    void Start()
    {
        #region Assignment
            _rigidbody = GetComponent<Rigidbody>();
            _avatar = GameObject.Find("Avatar");
            #endregion
    }

    void Update()
    {
        #region Movement
            _rigidbody.AddForce
                ((_avatar.transform.position - transform.position).normalized * _velocity);
            #endregion
       
    }
}

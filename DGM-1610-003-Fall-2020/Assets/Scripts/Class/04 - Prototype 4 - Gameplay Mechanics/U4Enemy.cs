using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U4Enemy : MonoBehaviour
{
    private float _velocity = 3.0f;
    
    private Rigidbody _rb;

    private GameObject _player;

    void Start()
    {
        #region Assignment
            _rb = GetComponent<Rigidbody>();
            _player = GameObject.Find("Player");
            #endregion
    }

    void Update()
    {
        #region A.I. Movement
        //Enemy Seeks Player
            Vector3 vectorPlayer = _player.transform.position - transform.position; //"Look Direction"
            _rb.AddForce(vectorPlayer.normalized * _velocity);
            #endregion
    }
}

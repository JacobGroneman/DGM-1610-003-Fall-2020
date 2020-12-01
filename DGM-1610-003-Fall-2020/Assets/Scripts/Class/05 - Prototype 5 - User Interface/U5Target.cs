using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U5Target : MonoBehaviour
{
    private float
        _minVelocity = 12, _maxVelocity = 16,
        _maxTorque = 10,
        _xRange = 4, _ySPawnPos = 6; 

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(RandomForce(), ForceMode.Impulse);
        _rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    void Update()
    {
        
    }

    #region Interactions
        void OnMouseDown()
        {
            Destroy(gameObject);
        }
    
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
        #endregion

    #region Attitude
         Vector3 RandomSpawnPos()
         {
             return new Vector3(Random.Range(-_xRange, _xRange), _ySPawnPos);
         }
        
         Vector3 RandomForce()
         {
             return Vector3.up * Random.Range(-_maxTorque, _maxTorque);
         }
        
         float RandomTorque()
         {
             return Random.Range(-_maxTorque, _maxTorque);
         }
         #endregion
}

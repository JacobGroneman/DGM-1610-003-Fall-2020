using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U5Target : MonoBehaviour
{
    private float
        _minVelocity = 12, _maxVelocity = 16,
        _maxTorque = 10,
        _xRange = 4, _ySPawnPos = 6;

    public int PointValue;
    
    private Rigidbody _rb;
    public ParticleSystem ExplosionParticle;

    private U5Manager _gameManager;

    void Start()
    {
        #region Initializing
        _gameManager = GameObject.Find("Game Manager")
                .GetComponent<U5Manager>();
                #endregion
                
        #region Physics
            _rb = GetComponent<Rigidbody>();
            _rb.AddForce(RandomForce(), ForceMode.Impulse);
            _rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            
            transform.position = RandomSpawnPos();
            #endregion
    }

    void Update()
    {
        
    }

    #region Interacting
        void OnMouseDown()
        {
            if (_gameManager.IsGameActive)
            {
                Destroy(gameObject);
                Instantiate
                    (ExplosionParticle, transform.position, ExplosionParticle.transform.rotation);
                _gameManager.UpdateScore(PointValue);
            }
        }
    
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            
            if (!gameObject.CompareTag("Bad"))
            {
                _gameManager.GameOver();
            }
        }
        #endregion

    #region Attitudes
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

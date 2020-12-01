using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U5Target : MonoBehaviour
{ 
    //Attitude
        private float
            _minVelocity = 12, _maxVelocity = 16,
            _maxTorque = 10,
            _xRange = 4, _ySPawnPos = 6; 
    //Value
        public int PointValue; 
    //Components
        private Rigidbody _rb;
        public ParticleSystem ExplosionParticle;
    //External
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

    #region Interacting
        void OnMouseDown()
        {
            //Good Targets
                if (_gameManager.IsGameActive)
                {
                    Destroy(gameObject);
                    Instantiate
                        (ExplosionParticle, transform.position, ExplosionParticle.transform.rotation);
                    _gameManager.UpdateScore(PointValue);
                } 
            //Skull
                if (gameObject.CompareTag("Bad"))
                {
                    _gameManager.GameOver();
                }
        }
        //Out-of-Bounds Behavior
            private void OnTriggerEnter(Collider other)
            {
                Destroy(gameObject);
                
                if (!gameObject.CompareTag("Bad"))
                {
                    _gameManager.GameOver();
                }
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

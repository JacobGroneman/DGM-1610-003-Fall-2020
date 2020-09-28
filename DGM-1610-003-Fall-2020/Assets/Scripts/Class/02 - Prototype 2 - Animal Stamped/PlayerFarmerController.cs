using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFarmerController : MonoBehaviour
{
    private float _horizontalInput;
    private float _velocity = 20f;

    private float _xRange = 20f;

    public GameObject Projectile;
    
    void Update()
    {
        #region Input
        //Horizontal Input
            _horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate
                (Vector3.right * _horizontalInput * _velocity * Time.deltaTime);
        // Horizontal Input Player Boundaries
            if (transform.position.x >= _xRange)
            {
                transform.position = new Vector3
                    (_xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= -_xRange)
            {
                transform.position = new Vector3
                    (-_xRange, transform.position.y, transform.position.z);
            }
            
        //Space-bar Input Fish Launch!
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Projectile, transform.position, Projectile.transform.rotation);
            }
            #endregion
    }
}

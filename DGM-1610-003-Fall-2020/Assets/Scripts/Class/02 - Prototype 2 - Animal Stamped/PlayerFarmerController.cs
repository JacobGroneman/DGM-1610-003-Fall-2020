using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerFarmerController : MonoBehaviour
{
    private float _horizontalInput;
    private float _velocity = 20f;
    
    void Update()
    {
        #region Input
        //Horizontal Input
            _horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate
                (Vector3.right * _horizontalInput * _velocity * Time.deltaTime);
        // Horizontal Input Player Boundaries
            if (transform.position.x >= 10)
            {
                transform.position = new Vector3
                    (10, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= -10)
            {
                transform.position = new Vector3
                    (-10, transform.position.y, transform.position.z);
            }
            
        //Space-bar Input Fish Launch!
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
            }
            #endregion
    }
}

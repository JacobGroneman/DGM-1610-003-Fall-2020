using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFarmerController : MonoBehaviour
{
    private float _horizontalInput;
    
    void Update()
    {
        #region Input
            _horizontalInput = Input.GetAxis("Horizontal");
            #endregion
    }
}

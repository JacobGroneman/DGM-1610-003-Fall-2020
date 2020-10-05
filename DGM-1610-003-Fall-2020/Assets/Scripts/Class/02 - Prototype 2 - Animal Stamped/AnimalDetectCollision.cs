using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDetectCollision : MonoBehaviour
{
    #region Collisions
        void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }    
            #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroy : MonoBehaviour
{
    private float _upperBounds = 30f;
    private float _lowerBounds = -10;
    
    void Update()
    {
        #region Destroy
        //Destroy Parameters
            if (transform.position.z >= _upperBounds)
            {    
                Destroy(this.gameObject);    
            }
            else if (transform.position.z <= _lowerBounds)
            {
                Destroy(this.gameObject);
            }
            #endregion
    }
}

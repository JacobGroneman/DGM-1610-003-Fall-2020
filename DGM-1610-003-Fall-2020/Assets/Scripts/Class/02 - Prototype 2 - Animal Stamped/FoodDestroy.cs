using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroy : MonoBehaviour
{
    private float _upperBounds = 30f;
    private float _lowerBounds = -10f;
    
    void Update()
    {
        #region Destroy
        //Destroy Parameters
            if (transform.position.z >= _upperBounds)
            {    
                Destroy(this.gameObject);    
            }
            //(For Animals)
            else if (transform.position.z <= _lowerBounds)
            {
                Destroy(this.gameObject);
                Debug.Log("GAME OVER");
                Time.timeScale = 0f;
            }
            #endregion
    }
}

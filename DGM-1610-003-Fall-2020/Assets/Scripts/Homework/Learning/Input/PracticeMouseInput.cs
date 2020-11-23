using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PracticeMouseInput : MonoBehaviour
{
    void Update()
    {
        #region Dubug
        //Returns Mouse Position (Vector 3)
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log(Input.mousePosition);
            }
            #endregion
    }
}

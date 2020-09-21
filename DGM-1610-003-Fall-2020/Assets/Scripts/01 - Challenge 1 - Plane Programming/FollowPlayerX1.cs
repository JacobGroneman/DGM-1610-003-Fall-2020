using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX1 : MonoBehaviour
{
    private GameObject _plane;
    private Vector3 _cameraOffset = new Vector3(29, 0, 11);

    void Start()
    {
        #region Locate
            _plane = GameObject.Find("Player");
            #endregion
    }

    void Update()
    {
        #region Placement
            //Positions the camera using offset
                var planePosition = _plane.transform.position;
                transform.position = planePosition + _cameraOffset;
                #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeClickDrag : MonoBehaviour
{
    private Vector3 _mouseOffset;

    private float _mouseZCoordinate;
    
    void OnMouseDown()
    {
        _mouseZCoordinate =
            Camera.main.WorldToScreenPoint
                (gameObject.transform.position).z;
        _mouseOffset = 
            gameObject.transform.position - GetMouseWorldPosition();
    }

    private Vector3 GetMouseWorldPosition()
    {
        //Pixel Coordinate System
            Vector3 mousePoint = Input.mousePosition;
        //Z Coordinate is the Game Object's
            mousePoint.z = _mouseZCoordinate;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    void OnMouseDrag()
    {
        transform.position =
            GetMouseWorldPosition() + _mouseOffset;
    }
    
}

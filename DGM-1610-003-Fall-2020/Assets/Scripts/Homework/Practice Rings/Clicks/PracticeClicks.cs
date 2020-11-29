using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeClicks : MonoBehaviour
{
    private Vector3 mousePosition;
    private Rigidbody rb;
    private Vector2 vectorMouse;
    private float moveSpeed = 100f;
    
    private float _mouseZCoordinate;

    private bool _held;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
    // Update is called once per frame
    void Update () 
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _held = true;
        }
        
        if ( _held == true)
        {
            GetMouseWorldPosition();
            vectorMouse = (mousePosition - transform.position);
            rb.velocity = new Vector2(vectorMouse.x * moveSpeed, vectorMouse.y * moveSpeed);
        }
        else if (_held == false)
        {
            rb.velocity = Vector2.zero;
        }
    }
    
    private Vector3 GetMouseWorldPosition()
    {
        //Pixel Coordinate System
        Vector3 mousePosition = Input.mousePosition;
        //Z Coordinate is the Game Object's
        mousePosition.z = _mouseZCoordinate;
        
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
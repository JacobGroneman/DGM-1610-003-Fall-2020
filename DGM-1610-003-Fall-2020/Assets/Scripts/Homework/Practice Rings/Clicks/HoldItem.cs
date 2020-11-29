using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    private Vector3 screenPoint;
 
    void Start () {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }
 
    void Update () {
        Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint);
        transform.position = curPosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBus : MonoBehaviour
{
    private GameObject bus;
    private Vector3 cameraOffset = new Vector3(0, 12, -12);

    void Start()
    {
        bus = GameObject.Find("Bus");
    }


    void FixedUpdate()
    {
        //Camera Main Follow Bus Position
        var busPosition = bus.transform.position;
        transform.position = busPosition + cameraOffset;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch3SpinObjects : MonoBehaviour
{
    public float spinSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}

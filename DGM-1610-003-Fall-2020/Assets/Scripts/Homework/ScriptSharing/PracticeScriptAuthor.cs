using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeScriptAuthor : MonoBehaviour
{
    public float velocity = 5;
    private float _storedVelocity = 0;

    void Start()
    {
        _storedVelocity = velocity;
    }

    void Update()
    {
        _storedVelocity = velocity;
    }
}

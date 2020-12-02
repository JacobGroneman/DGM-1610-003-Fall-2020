using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeGetSet : MonoBehaviour
{
    private int _score;
    private int _highScore;

    public int Score
    {
        get => _score;
        set { if (value == _highScore) {UnityEngine.Debug.Log
                ("You set a new high score!");} 
            _score = value;}
    }

    void Update()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
        }
    }
}

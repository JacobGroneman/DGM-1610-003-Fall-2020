using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticePointsArray : MonoBehaviour
{
    private int _points = 0;
    
    public string[] pointsPrompts =
    {
        "Get those points!",
        "25%! Get Those Moneys!!",
        "50%! Halfway There!",
        "75%! One more Checkpoint!",
        "100%! You Just Won!"
    };

    public ParticleSystem fireWorks;

    public Scene WinScene;
    
    void Start()
    {
        Debug.Log(pointsPrompts[0]);
        fireWorks = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (_points == 25)
        {
            Debug.Log(pointsPrompts[1]);
        }
        if (_points == 50)
        {
            Debug.Log(pointsPrompts[2]);
        }
        if (_points == 75)
        {
            Debug.Log(pointsPrompts[3]);
        }
        if (_points == 100)
        {
            Debug.Log(pointsPrompts[4]);
            GameWon();
        }
    }

    void OnColliderEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Points") && _points < 100)
        {
            _points += 5;
        }
        
        if (other.gameObject.CompareTag("Thieves") && _points > 0)
        {
            _points -= 5;
        }
    }

    void GameWon()
    {
        fireWorks.Play();
        var loadWinScene = WinScene.isLoaded == true;
    }
}

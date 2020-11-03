using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ch3UIManager : MonoBehaviour
{
    public Ch3PlayerController player;
    public Text pointsText;

    void Update()
    {
        pointsText.text = "Points: " + player.points;

        if (player.gameOver == true)
        {
            pointsText.text = "GAME OVER!";
        }
    }
}

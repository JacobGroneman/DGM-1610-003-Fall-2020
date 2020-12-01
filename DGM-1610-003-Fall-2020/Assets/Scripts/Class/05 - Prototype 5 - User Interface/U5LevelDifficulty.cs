using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U5LevelDifficulty : MonoBehaviour
{
    public int Difficulty;

    private Button _button;
    
    private U5Manager _gameManager;
    
    void Start()
    {
        #region Initializing
            _gameManager = GameObject.Find("Game Manager").GetComponent<U5Manager>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(SetDifficulty);
            #endregion
    }

    void SetDifficulty()
    {
        _gameManager.StartGame(Difficulty);
    }
}

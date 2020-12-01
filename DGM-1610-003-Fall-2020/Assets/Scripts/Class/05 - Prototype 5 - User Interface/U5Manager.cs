using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using  TMPro;


public class U5Manager : MonoBehaviour
{
    public bool IsGameActive;

    //Targets
        public List<GameObject> Targets;
        private float _spawnInterval = 1.0f;
    //Score
        private int _score;
        private TextMeshProUGUI _scoreText;
    //Game Over
        public TextMeshProUGUI GameOverText;
        public Button RestartButton;

        void Start()
    {
        IsGameActive = true;
        
        #region Setting GUI
        //Score
            _scoreText = GameObject.Find("Score Text")
                .GetComponent<TextMeshProUGUI>();
            _score = 0;
            UpdateScore(0);
            #endregion
        
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(_spawnInterval);
            
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = "Score: " + _score;
    }

    #region Postal
        public void GameOver()
        {
            RestartButton.gameObject.SetActive(true);
            GameOverText.gameObject.SetActive(true);
            IsGameActive = false;
        }
    
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion
}

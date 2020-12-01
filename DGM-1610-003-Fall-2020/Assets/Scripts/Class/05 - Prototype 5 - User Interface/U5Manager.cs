using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using  TMPro;


public class U5Manager : MonoBehaviour
{
    //Game State
        public bool IsGameActive;
    //Targets
        public List<GameObject> Targets;
        private float _spawnInterval = 1.0f;
    //Score
        private int _score;
        private TextMeshProUGUI _scoreText;
    //Title Screen
        public GameObject TitleScreen;
    //Game Over
        public TextMeshProUGUI GameOverText;
        public Button RestartButton;
        
    #region Gameplay
        public void StartGame(int difficulty)
        {
            //Start Game GUI and Bool
                TitleScreen.gameObject.SetActive(false);
                IsGameActive = true;
            //Score GUI
                _scoreText = GameObject.Find("Score Text")
                    .GetComponent<TextMeshProUGUI>();
                _score = 0;
                UpdateScore(0);
            //Set and Start Game (coRoutine)
                 _spawnInterval /= difficulty;
                StartCoroutine(SpawnTarget());
        }
    //Spawns targets based on _spawnInterval
        IEnumerator SpawnTarget()
        {
            while (IsGameActive)
            {
                yield return new WaitForSeconds(_spawnInterval);
            
                int index = Random.Range(0, Targets.Count);
                Instantiate(Targets[index]);
            }
        }
    //Updates Score and Score GUI
        public void UpdateScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            _scoreText.text = "Score: " + _score;
        }
        #endregion
    

    #region Post Game
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

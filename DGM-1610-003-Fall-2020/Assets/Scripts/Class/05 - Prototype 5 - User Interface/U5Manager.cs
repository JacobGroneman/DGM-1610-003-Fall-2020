using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using  TMPro;
using UnityEngine.UI;

public class U5Manager : MonoBehaviour
{
    //Targets
        public List<GameObject> Targets;
        private float _spawnInterval = 1.0f;
    //Score
        private int _score;
        public TextMeshProUGUI ScoreText;

    void Start()
    {
        #region Setting GUI
            ScoreText = GameObject.Find("Score Text")
                .GetComponent<TextMeshProUGUI>();
            _score = 0;
            ScoreUpdate(0);
            #endregion
        
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);
            
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);
        }
    }

    public void ScoreUpdate(int scoreToAdd)
    {
        _score += scoreToAdd;
        ScoreText.text = "Score: " + _score;
    }
    
}

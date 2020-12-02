using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerRing : MonoBehaviour
{
        public bool PlayClicked = false;
    //UIs
        private GameObject _titleUi;
            public Button[] TitleButtons;
            private float uiCenterX = 513.3981f;
            private float _velocity = 200f;
        public GameObject InstructionsUi;
        public GameObject QuitPromptUi;
            public bool IsQuitPromptOn;

        private RingPuzzleDraft _gameManager;
        
        void Start()
    {
        #region Initializing
            _titleUi = GameObject.Find("Title UI");
            _gameManager = GameObject.Find("Main Camera").
                GetComponent<RingPuzzleDraft>();
            #endregion
    }
    
    void Update()
    {
        if (_titleUi.transform.position.x < uiCenterX && PlayClicked == false)
        {
            _titleUi.transform.Translate(Vector3.right * _velocity * Time.deltaTime);
        }

        if (PlayClicked == true && _titleUi.transform.position.x < (uiCenterX + 1000))
        {
            _titleUi.transform.Translate(Vector3.right * _velocity * Time.deltaTime);
        }
    }

    #region ButtonActions

        public void PlayPuzzle()
        {
            PlayClicked = true;
            
            foreach (var button in TitleButtons)
            {
                button.GetComponent<Button>().interactable = false;
            }
            
            _gameManager.enabled = true;
        }
        
        public void Instructions()
        {
            _titleUi.SetActive(false);
            InstructionsUi.SetActive(true);
        }

        public void Menu()
        {
            InstructionsUi.SetActive(false);
            _titleUi.SetActive(true);
        }
        
    //Quit Prompt
    public void Yes()
    {
        _gameManager.QuitGame();
    }
    public void No()
    {
        QuitPromptUi.SetActive(false);
        IsQuitPromptOn = false;
    }
    #endregion
}

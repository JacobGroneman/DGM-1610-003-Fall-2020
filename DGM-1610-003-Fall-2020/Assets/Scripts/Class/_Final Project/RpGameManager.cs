using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RpGameManager : MonoBehaviour
{
    public bool IsGameActive;

    public GameObject Peg1, Peg2, Peg3;
    public GameObject Disk1, Disk2, Disk3, Disk4, Disk5;
    public List<GameObject> HeldDisk;
    public List<GameObject> Pegs;

    public RpUIManager UiManager;

    void Start()
    {
        UiManager = GameObject.Find("UI Manager")
            .GetComponent<RpUIManager>();
        
        Peg1 = GameObject.Find("Peg 1");
        Peg2 = GameObject.Find("Peg 2");
        Peg3 = GameObject.Find("Peg 3");

        Disk1 = GameObject.Find("Disk one");
        Disk2 = GameObject.Find("Disk two");
        Disk3 = GameObject.Find("Disk three");
        Disk4 = GameObject.Find("Disk four");
        Disk5 = GameObject.Find("Disk five");

        SetDisksToPegOne();
    }
    void Update()
    {
        OnGameWinning();

        if (UiManager.IsQuitPromptOn == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Peg1.GetComponent<RpPeg>().HoldDropDisk();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Peg2.GetComponent<RpPeg>().HoldDropDisk();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Peg3.GetComponent<RpPeg>().HoldDropDisk();
            }
        
            ClickPeg(Peg1);
            ClickPeg(Peg2);
            ClickPeg(Peg3);
        
            if (Input.GetKeyDown(KeyCode.E) && UiManager.PlayClicked)
            {
                ResetRings();
            }   
        }

        QuittingMechanic();
    }

    void OnGameWinning()
    {
        if (Peg3.GetComponent<RpPeg>().Disks.Count == 5)
        {
            Debug.Log("You Won the Game");
        }
    }
    
    void ClickPeg(GameObject clickedPeg)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == clickedPeg)
                {
                    clickedPeg.GetComponent<RpPeg>().HoldDropDisk();
                }
            }
        }
    }

    #region Reset & Quit
        private void ResetRings()
        {
            foreach (var peg in Pegs)
            {
                if (peg.GetComponent<RpPeg>().Disks.Count != 0)
                {
                    peg.GetComponent<RpPeg>().Disks.Clear();
                }
            }
    
            if (HeldDisk.Count != 0)
            {
                HeldDisk.Last().GetComponent<RpHoldItem>().enabled = false;
                HeldDisk.Clear();
            }
            
            SetDisksToPegOne();
        }

        void QuittingMechanic()
        {
            if (Input.GetKeyDown(KeyCode.Q) && UiManager.IsQuitPromptOn == false && UiManager.PlayClicked)
            {
                UiManager.QuitPromptUi.SetActive(true);
                UiManager.IsQuitPromptOn = true;
            }
            else if (Input.GetKeyDown(KeyCode.Q) && UiManager.IsQuitPromptOn)
            {
                UiManager.No();
            }
        }
        public void QuitGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion
    
    void SetDisksToPegOne()
    {
        Peg1.GetComponent<RpPeg>().Disks.Add(Disk5);
        Peg1.GetComponent<RpPeg>().Disks.Add(Disk4);
        Peg1.GetComponent<RpPeg>().Disks.Add(Disk3);
        Peg1.GetComponent<RpPeg>().Disks.Add(Disk2);
        Peg1.GetComponent<RpPeg>().Disks.Add(Disk1);
    }
}


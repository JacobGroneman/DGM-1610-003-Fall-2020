using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RpGameManager : MonoBehaviour
{
    public bool IsGameActive;
    public bool IsGameWon;

    public GameObject Peg1, Peg2, Peg3;
    public GameObject Disk1, Disk2, Disk3, Disk4, Disk5;
    public List<GameObject> HeldDisk;
    public List<GameObject> Pegs;
    public ParticleSystem winParticle;
    public RpUIManager UiManager;

    void Start()
    {
        UiManager = GameObject.Find("UI Manager")
            .GetComponent<RpUIManager>();
        
        Peg1 = GameObject.Find("Peg one");
        Peg2 = GameObject.Find("Peg two");
        Peg3 = GameObject.Find("Peg three");

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

        if (UiManager.IsQuitPromptOn == false && IsGameWon == false)
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
            
            if (Input.GetKeyDown(KeyCode.E) && UiManager.PlayClicked)
            {
                ResetRings();
            }
        }

        if (!IsGameWon)
        {
            QuittingMechanic();
        }
    }

    void OnGameWinning()
    {
        if (Peg3.GetComponent<RpPeg>().Disks.Count == 5)
        {
            IsGameWon = true;
            winParticle.Play();
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
                HeldDisk.Last().GetComponent<MeshCollider>().isTrigger = false;
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
        
        Peg1.GetComponent<RpPeg>().DiskPlacement();
    }
}


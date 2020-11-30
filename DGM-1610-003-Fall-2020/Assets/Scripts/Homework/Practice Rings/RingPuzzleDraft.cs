using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPuzzleDraft : MonoBehaviour
{
    public GameObject Peg1, Peg2, Peg3;
    public GameObject Disk1, Disk2, Disk3, Disk4, Disk5;
    public List<GameObject> HeldDisk;

    void Start()
    {
        Peg1 = GameObject.Find("Peg 1");
        Peg2 = GameObject.Find("Peg 2");
        Peg3 = GameObject.Find("Peg 3");

        Disk1 = GameObject.Find("Disk one");
        Disk2 = GameObject.Find("Disk two");
        Disk3 = GameObject.Find("Disk three");
        Disk4 = GameObject.Find("Disk four");
        Disk5 = GameObject.Find("Disk five");

        Peg1.GetComponent<Peg>().Disks.Add(Disk5);
        Peg1.GetComponent<Peg>().Disks.Add(Disk4);
        Peg1.GetComponent<Peg>().Disks.Add(Disk3);
        Peg1.GetComponent<Peg>().Disks.Add(Disk2);
        Peg1.GetComponent<Peg>().Disks.Add(Disk1);
    }
    void Update()
    {
        OnGameWinning();

        if (Input.GetKeyDown(KeyCode.S))
        {
            Peg1.GetComponent<Peg>().HoldDropDisk();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Peg2.GetComponent<Peg>().HoldDropDisk();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Peg3.GetComponent<Peg>().HoldDropDisk();
        }
        
        ClickPeg(Peg1);
        ClickPeg(Peg2);
        ClickPeg(Peg3);
    }

    void OnGameWinning()
    {
        if (Peg3.GetComponent<Peg>().Disks.Count == 5)
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
                    clickedPeg.GetComponent<Peg>().HoldDropDisk();
                }
            }
        }
    }
}


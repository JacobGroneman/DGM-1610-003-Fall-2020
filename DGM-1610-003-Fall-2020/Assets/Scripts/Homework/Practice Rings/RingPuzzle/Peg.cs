using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Peg : MonoBehaviour
{
    public List<GameObject> Disks;
    
    public float
        YPos1 = -0.4753096f,
        YPos2 = 0.3917079f,
        YPos3 = 1.257478f,
        YPos4 = 2.12836f,
        YPos5 = 2.99798298f;

    private Vector3 Disks1Pos, Disks2Pos, Disks3Pos, Disks4Pos, Disk5Pos;
    private RingPuzzleDraft _gameManager;

    public Vector3 PegPos;

    void Start()
    { 
        PegPos = transform.position;
        _gameManager = GameObject.Find("Main Camera").GetComponent<RingPuzzleDraft>();
    }

    void Update()
    {
        DiskPlacement();
    }

    void DiskPlacement()
    {
        Disks[0].transform.position = new Vector3(PegPos.x, YPos1, PegPos.z);
        Disks[1].transform.position = new Vector3(PegPos.x, YPos2, PegPos.z);
        Disks[2].transform.position = new Vector3(PegPos.x, YPos3, PegPos.z);
        Disks[3].transform.position = new Vector3(PegPos.x, YPos4, PegPos.z);
        Disks[4].transform.position = new Vector3(PegPos.x, YPos5, PegPos.z);
    }
    
    public void HoldDropDisk()
    {
        if (_gameManager.HeldDisk.Count == 0)
        {
            HoldDisk();
        }
        else if (_gameManager.HeldDisk.Count != 0)
        {
            //If Held Disk is Smaller than Peg.Last
            if (Disks.Count == 0)
            {
                DropDisk();
            }
            else if (Disks.Count != 0 &&_gameManager.HeldDisk.Last().transform.lossyScale.x < 
                                     Disks.Last().transform.lossyScale.x)
            {
                DropDisk();
            }
        }
    }
    private void HoldDisk()
    {
        Disks.Last().GetComponent<HoldItem>().enabled = true;
        _gameManager.HeldDisk.Add(Disks.Last());
        Disks.Remove(Disks.Last());
    }

    private void DropDisk()
    {
        _gameManager.HeldDisk.Last().GetComponent<HoldItem>().enabled = false;
        Disks.Add(_gameManager.HeldDisk.Last());
        _gameManager.HeldDisk.Remove(_gameManager.HeldDisk.Last());
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RpPeg : MonoBehaviour
{
    public List<GameObject> Disks;

    public float
        YPos1 = 0.7198f,
        YPos2 = 1.990718f,
        YPos3 = 3.169652f,
        YPos4 = 4.221679f,
        YPos5 = 4.662696f;

    private Vector3 Disks1Pos, Disks2Pos, Disks3Pos, Disks4Pos, Disk5Pos;
    private RpGameManager _gameManager;

    public Vector3 PegPos;

    void Start()
    { 
        PegPos = transform.position;
        _gameManager = GameObject.Find("Game Manager").GetComponent<RpGameManager>();
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
        Disks.Last().GetComponent<RpHoldItem>().enabled = true;
        _gameManager.HeldDisk.Add(Disks.Last());
        Disks.Remove(Disks.Last());
        
        _gameManager.HeldDisk.Last().transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void DropDisk()
    {
        _gameManager.HeldDisk.Last().GetComponent<RpHoldItem>().enabled = false;
        Disks.Add(_gameManager.HeldDisk.Last());
        _gameManager.HeldDisk.Remove(_gameManager.HeldDisk.Last());
        
        Disks.Last().transform.position = new Vector3(PegPos.x, 5.66f, PegPos.z);
        Disks.Last().transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}

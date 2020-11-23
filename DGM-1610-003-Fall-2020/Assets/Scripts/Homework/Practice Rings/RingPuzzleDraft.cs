using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RingPuzzleDraft : MonoBehaviour
{
    public Dictionary<GameObject, int> Peg1;
    public Dictionary<GameObject, int> Peg2;
    public Dictionary<GameObject, int> Peg3;
        
    private GameObject _1Ring, _2Ring, _3Ring, _4Ring, _5Ring;

    private Dictionary<GameObject, int> _heldDisk;

    void Start()
    {
        #region Initialize
            _1Ring = GameObject.Find("Ring 1");
            _2Ring = GameObject.Find("Ring 2");
            _3Ring = GameObject.Find("Ring 3");
            _4Ring = GameObject.Find("Ring 4");
            _5Ring = GameObject.Find("Ring 5");
    
            Peg1.Add(_5Ring, 5);
            Peg1.Add(_4Ring, 4);
            Peg1.Add(_3Ring, 3);
            Peg1.Add(_2Ring, 2);
            Peg1.Add(_1Ring, 1); //Find a More Simple Way
            
            /* Initialize Disk Positions */
            #endregion
    }

    void Update()
    {
        /* Click Disk
        {
        NEED THIS METHOD FOR ALL CLICKS
            HeldItem.Add(Peg1.LastItem)
            Peg1.Remove(LastItem)
            HeldDisk.Disk.Transform.position == mousePosition
        }
        
            if(!_heldDisk == null && _heldDisk.LastItem.GameObject < peg1.LastItem)
            {
                Peg1.Add(HeldDisk.disk)
                _HeldItem.Remove(Disk)
                Transform the disk on top of the other one            
            }
            Else if(!_heldDisk == null && _heldDisk.LastItem.GameObject < peg2.LastItem)
            {
                Peg2.Add(HeldDisk.disk)
                _HeldItem.Remove(Disk)
                Transform the disk on top of the other one            
            }
            Else if(!_heldDisk == null && _heldDisk.LastItem.GameObject < peg3.LastItem)
            {
                Peg3.Add(HeldDisk.disk)
                _HeldItem.Remove(Disk)
                Transform the disk on top of the other one
            }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RingPuzzleDraft : MonoBehaviour
{
    public List<GameObject> Peg1;
    public List<GameObject> Peg2;
    public List<GameObject> Peg3;

    public GameObject _1Ring,_2Ring, _3Ring, _4Ring, _5Ring;

    private List<GameObject> _heldDisk;

    private Vector3 _1RingPos = new Vector3
        (-12, 2.99798298f, 0);
    private Vector3 _2RingPos = new Vector3
        (-12, 2.12836f, 0);
    private Vector3 _3RingPos = new Vector3
        (-12, 1.257478f, 0);
    private Vector3 _4RingPos = new Vector3
        (-12, 0.3917079f, 0);
    private Vector3 _5RingPos = new Vector3
        (-12, -0.4753096f, 0);
    
    void Start()
    {
        #region Initialize
            _1Ring = GameObject.Find("Ring one");
            _2Ring = GameObject.Find("Ring two");
            _3Ring = GameObject.Find("Ring three");
            _4Ring = GameObject.Find("Ring four");
            _5Ring = GameObject.Find("Ring five");
    
            _1Ring.transform.position = _1RingPos;
            _2Ring.transform.position = _2RingPos;
            _3Ring.transform.position = _3RingPos;
            _4Ring.transform.position = _4RingPos;
            _5Ring.transform.position = _5RingPos;
            
            Peg1.Add(_5Ring);
            Peg1.Add(_4Ring);
            Peg1.Add(_3Ring);
            Peg1.Add(_2Ring);
            Peg1.Add(_1Ring);
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
        
            if(!_heldDisk == null && _heldDisk.LastItem.GameObject < peg1.LastItem 
                || !_heldDisk == null && Peg1 == Null)
            {
                Peg1.Add(HeldDisk.disk)
                _HeldItem.Remove(Disk)
                Transform the disk on top of the other one            
            }
            Else if(!_heldDisk == null && _heldDisk.LastItem.GameObject < peg2.LastItem 
                    || !_heldDisk == null && Peg2 == Null)
            {
                Peg2.Add(HeldDisk.disk)
                _HeldItem.Remove(Disk)
                Transform the disk on top of the other one            
            }
            Else if(!_heldDisk == null && _heldDisk.LastItem.GameObject < peg3.LastItem 
                    || !_heldDisk == null && Peg3 == Null)
            {
                Peg3.Add(HeldDisk.disk)
                _HeldItem.Remove(Disk)
                Transform the disk on top of the other one
            }
        */
    }
}

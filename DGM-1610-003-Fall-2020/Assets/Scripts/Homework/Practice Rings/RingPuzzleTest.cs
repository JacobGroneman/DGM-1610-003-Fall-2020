using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RingPuzzleTest : MonoBehaviour
{
    public class Ring
    {
        public bool IsOnTop;
        public GameObject obj;
    }
    
    public List<Ring> Peg1;
    public List<Ring> Peg2;
    public List<Ring> Peg3;

    public Ring _1Ring, _2Ring, _3Ring, _4Ring, _5Ring;

    private List<GameObject> _heldDisk;

    void Start()
    {
        #region Initialize

        _1Ring.obj = GameObject.Find("Ring one");
        _2Ring.obj = GameObject.Find("Ring two");
        _3Ring.obj = GameObject.Find("Ring three");
        _4Ring.obj = GameObject.Find("Ring four");
        _5Ring.obj = GameObject.Find("Ring five");
    
        Peg1.Add(_5Ring);
        Peg1.Add(_4Ring);
        Peg1.Add(_3Ring);
        Peg1.Add(_2Ring);
        Peg1.Add(_1Ring);
/* Initialize Disk Positions */
        #endregion
    }

    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class RingPuzzleTest : MonoBehaviour
{
    #region Variables
    //Pegs
        public List<GameObject> Rings;
        public List<GameObject> PegOne;
        public List<GameObject> PegTwo;
        public List<GameObject> PegThree;
    //Rings
        public GameObject _1Ring,_2Ring, _3Ring, _4Ring, _5Ring;
    //Held Ring
        public List<GameObject> _heldRing;
    //Ring Peg 1 Positions
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
        #endregion

    void Start()
    {
        #region Initialize
        //Assigns Rings to Variables
            _1Ring = GameObject.Find("Ring one");
            _2Ring = GameObject.Find("Ring two");
            _3Ring = GameObject.Find("Ring three");
            _4Ring = GameObject.Find("Ring four");
            _5Ring = GameObject.Find("Ring five");
        //Sets Ring Positions
            _1Ring.transform.position = _1RingPos;
            _2Ring.transform.position = _2RingPos;
            _3Ring.transform.position = _3RingPos;
            _4Ring.transform.position = _4RingPos;
            _5Ring.transform.position = _5RingPos;
        //Adds Rings to Peg 1
            PegOne.Add(_5Ring);
            PegOne.Add(_4Ring);
            PegOne.Add(_3Ring);
            PegOne.Add(_2Ring);
            PegOne.Add(_1Ring);
        //Adds Rings to Rings List for operations
            foreach (var ring in PegOne)
            {
                Rings.Add(ring);
            }
            #endregion
    }

    void Update()
    {
        HoldRing(PegOne);
        HoldRing(PegTwo);
        HoldRing(PegThree);

        //WORK ON THIS ONE!!! (assigning obj to Mouse according to world space)
        if (_heldRing.Count == 1)
        {
            _heldRing.Last().transform.position =
                new Vector3
                    (Input.mousePosition.x, Input.mousePosition.y, 0);
        }
    }

    private void HoldRing(List<GameObject> peg)
    {//Qualifies any Holding Peg's Last Ring to be Held, if none is Held
        foreach (var ring in Rings)
        {
            if (peg.Count != 0 && ring == peg.Last() && _heldRing.Count == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Transfer Ring to Held
                    _heldRing.Add(ring);
                    peg.Remove(ring);
                }
            }
        }
    }
}
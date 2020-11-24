using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RingPuzzleTest : MonoBehaviour
{
    public List<GameObject> Rings;
    public List<GameObject> PegOne;
    public List<GameObject> PegTwo;
    public List<GameObject> PegThree;

    public GameObject _1Ring,_2Ring, _3Ring, _4Ring, _5Ring;

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
    
    public List<GameObject> _heldRing;
    
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
        //Check Whether Ring is on Top
            /*foreach (var ring in Rings)
            {
                if (ring == PegOne.Last() 
                    || ring == PegTwo.Last()
                    || ring == PegThree.Last())
                {
                    //If clicked on:
                    _heldRing.Add(ring);
                }
            }*/
    }
}

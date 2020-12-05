using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RpDisk : MonoBehaviour
{
   private RpGameManager _gameManager;
   private List<GameObject> _pegs;

   void Start()
   {
      _gameManager = GameObject.Find("Game Manager").GetComponent<RpGameManager>();
     _pegs = _gameManager.Pegs;
   }
   void OnMouseDown()
   {
       foreach (var peg in _pegs)
       {
           if (gameObject == peg.GetComponent<RpPeg>().Disks.Last())
           {
               peg.GetComponent<RpPeg>().HoldDropDisk();
           }
       }
   }
}

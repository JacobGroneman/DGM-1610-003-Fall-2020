using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Enables Binary Serialization!!
public class PracticeSaveData : MonoBehaviour
{
    #region Singleton
        private static PracticeSaveData _current; 
        public static PracticeSaveData Current
        {
            get
            {
                if (_current == null)
                {_current = new PracticeSaveData();} 
                return Current;
            }
        }
        #endregion
        
        //https://www.youtube.com/watch?v=5roZtuqZyuw
        //[3:47]
}

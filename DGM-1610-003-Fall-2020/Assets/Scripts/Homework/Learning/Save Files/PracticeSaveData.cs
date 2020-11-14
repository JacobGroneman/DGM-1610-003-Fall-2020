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

        public PracticePlayerProfile PlayerProfile;
        
        public int BoughtWeapons;
        public int BoughtTrophys;

        #region Loading
            public void OnLoadGame()
            {
                PracticeSaveData._current = (PracticeSaveData) //May be Current
                    PracticeSerializationManager.Load(Application.persistentDataPath + "/saves/Save.save");
            }
            #endregion

    public void GetMoneys()
        {
            PracticeSaveData.Current.PlayerProfile.moneys += 100;
            PracticeSaveData.Current.PlayerProfile.experienceLevel += 1;
        }

    #region Shopping
    
        public void BuyWeapon()
            {
                if (PracticeSaveData.Current.PlayerProfile.moneys >= 200)
                {
                    PracticeSaveData.Current.PlayerProfile.moneys -= 200;
                    PracticeSaveData.Current.BoughtWeapons += 1;
                    //UpdateUI();
                }
            }
    
            public void BuyTrophy()
            {
                if (PracticeSaveData.Current.PlayerProfile.moneys >= 350)
                {
                    PracticeSaveData.Current.PlayerProfile.moneys -= 350;
                    PracticeSaveData.Current.BoughtTrophys += 1;
                    //UpdateUI();
                }
            }
            #endregion
        
        

        //https://www.youtube.com/watch?v=5roZtuqZyuw
        //[5:34]
}

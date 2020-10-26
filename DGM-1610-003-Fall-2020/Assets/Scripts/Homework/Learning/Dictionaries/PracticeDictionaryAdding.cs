using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public string itemName;
    public int itemID;
}

public class PracticeDictionaryAdding : MonoBehaviour
{
    public Dictionary<int, InventoryItem> Inventory 
        = new Dictionary<int, InventoryItem>();

    public InventoryItem
        wallet, keys, phone, gum;
    
    public int time = 9000;

    void Start()
    {
        wallet.itemName = "Wallet";
        wallet.itemID = 0;
        keys.itemName = "Keys";
        wallet.itemID = 1;
        phone.itemName = "Phone";
        phone.itemID = 2;
        gum.itemName = "Gum";
        gum.itemID = 3;
    }
    
    void Update()
    {
        if (time == 9050)
        {
            Inventory.Add(wallet.itemID, wallet);
            Inventory.Add(keys.itemID, keys);
            Inventory.Add(phone.itemID, phone);
            Inventory.Add(gum.itemID, gum);
        }
    }
}

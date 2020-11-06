using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PracticeItemSelection : MonoBehaviour
{
    public Dictionary<string, GameObject> inventory;

    public GameObject addedObject;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(inventory["Axe"], Vector3.zero, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        
        if (other.gameObject.CompareTag("Item"))
        {
            addedObject = GameObject.Find(other.name);
            inventory.Add(other.gameObject.name, addedObject);
        }
        
        //I Got to Research this Stuff
    }
}

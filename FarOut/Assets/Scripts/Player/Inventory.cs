using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Weapons weapon;

   
    private bool checkIfEquipped() 
    {
        if (weapon.isEquipped == true)
            return true;
        else
            return false;
    
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

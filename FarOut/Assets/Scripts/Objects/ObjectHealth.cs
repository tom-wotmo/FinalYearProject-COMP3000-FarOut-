using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public int objHealth = 1;
    public void takeDamage(int damage) 
    {
        objHealth = objHealth - damage; //can add multipliers here for damage difference

        if(objHealth <= 0) 
        {
            Destroy(this.gameObject);
        }

    }

}

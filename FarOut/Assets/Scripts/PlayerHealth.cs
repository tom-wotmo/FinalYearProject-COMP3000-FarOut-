using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playHealth = 1;
    public static bool isEnemyDead = false;

    public void TakeDamage(int damage) 
    {
        playHealth = playHealth - damage;
        
        if(playHealth <= 0)
        {
            Debug.Log("Dead");

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int playerHealth = 100;
   

    void Start()
    {
        StartCoroutine(RejenerateHealth());
    }
    //regenerates the players health slowly
    IEnumerator RejenerateHealth()
    {
        int regenAmount = 0;
        int regenRate = 0;

        while (true)
        {
            if (playerHealth < 100)
            {
                playerHealth += regenAmount;
                yield return new WaitForSeconds(regenRate);
            }
            else { yield return true; }
        }
    }


}

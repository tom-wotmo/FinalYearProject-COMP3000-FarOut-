using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int playerHealth = 100;
   

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
<<<<<<< Updated upstream
=======
    public void PlayerDeath()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Player Dead.");
        }
    }
    public int GetPlayerHealth()
    {
        return playerHealth;
    }
    public void SetPlayerHealth(int health)
    {
        playerHealth = health;
    }
>>>>>>> Stashed changes


}

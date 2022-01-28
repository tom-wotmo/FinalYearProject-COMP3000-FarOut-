using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]private int playerHealth = 100;

    void Update()
    {
        StartCoroutine(RejenerateHealth());

        Debug.Log(playerHealth);
    }
    private void Start()
    {
        playerHealth = 100;
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
    
    public int GetPlayerHealth()
    {
        return playerHealth;
    }
    public void SetPlayerHealth(int health)
    {
        playerHealth = health;
    }


}

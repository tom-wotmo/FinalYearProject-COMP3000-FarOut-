using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the health of the player
    //
    //
    //
    // 
    [SerializeField]private int currPlayerHealth = 100;
    [SerializeField]private Transform playerRespawn;
    [SerializeField]private GameObject player;
    [SerializeField]private int maximumPlayerHealth, minimumPlayerHealth;
    void Update()
    {
       // StartCoroutine(RejenerateHealth());

        PlayerDeath();
    }
    private void Start()
    {
        currPlayerHealth = 100;

        player = GameObject.FindGameObjectWithTag("Player");
    }
 
    //regenerates the players health slowly
    IEnumerator RejenerateHealth()
    {
        int regenAmount = 0;
        int regenRate = 0;

        while (true)
        {
            if (currPlayerHealth < maximumPlayerHealth)
            {
                currPlayerHealth += regenAmount;
                yield return new WaitForSeconds(regenRate);
            }
            else { yield return true; }
        }
    }
    IEnumerator RespawnHealth()
    {
        int maxHealth = 100;

        yield return new WaitForSeconds(1);

        SetPlayerHealth(maxHealth);
        
    }
    public void PlayerDeath()
    {
        if (currPlayerHealth <= minimumPlayerHealth)
        {
            StartCoroutine(RespawnHealth());

            player.transform.position = playerRespawn.transform.position;
        }
    }
    public int GetPlayerHealth()
    {
        return currPlayerHealth;
    }
    public int GetMaximumHealth()
    {
        return maximumPlayerHealth;
    }
    public int GetMinimumHealth()
    {
        return minimumPlayerHealth;
    }
    public void SetPlayerHealth(int health)
    {
        currPlayerHealth = health;
    }


}

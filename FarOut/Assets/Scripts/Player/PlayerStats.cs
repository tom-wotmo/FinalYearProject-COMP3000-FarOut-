using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]private int playerHealth = 100;
    [SerializeField] private Transform playerRespawn;
    private GameObject player;
    void Update()
    {
       // StartCoroutine(RejenerateHealth());

        PlayerDeath();
    }
    private void Start()
    {
        playerHealth = 100;

        player = GameObject.FindGameObjectWithTag("Player");
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
    IEnumerator RespawnHealth()
    {
        int maxHealth = 100;

        yield return new WaitForSeconds(1);

        SetPlayerHealth(maxHealth);
        
    }
    public void PlayerDeath()
    {
        if (playerHealth <= 0)
        {
            StartCoroutine(RespawnHealth());

            player.transform.position = playerRespawn.transform.position;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField]private Slider playerHealthSlider;
    [SerializeField] private int regenAmount, regenRate;
    void Update()
    {
       // StartCoroutine(RejenerateHealth());
       //if(currPlayerHealth < maximumPlayerHealth)
       // {
       //     StartCoroutine(RejenerateHealth());
       // }

        PlayerDeath();

        if (currPlayerHealth !< maximumPlayerHealth)
        {
            playerHealthSlider.value = currPlayerHealth;
        }
    }
    private void Start()
    {
        currPlayerHealth = 100;

        player = GameObject.FindGameObjectWithTag("Player");
    }
 
    //regenerates the players health slowly
    IEnumerator RejenerateHealth()
    {
      
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

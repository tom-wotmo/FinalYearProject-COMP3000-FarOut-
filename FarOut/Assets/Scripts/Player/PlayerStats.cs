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
    [SerializeField]private int currPlayerHealth;
    [SerializeField]private Transform playerRespawn;
    [SerializeField]private GameObject player;
    [SerializeField]private int maximumPlayerHealth, minimumPlayerHealth;
    [SerializeField]private Slider playerHealthSlider;
    [SerializeField]private int regenAmount, regenRate;
    private bool isRegenHealth;
    void Update()
    {
        // StartCoroutine(RejenerateHealth());
        //if(currPlayerHealth < maximumPlayerHealth)
        // {
        //     StartCoroutine(RejenerateHealth());
        // }

        if (currPlayerHealth != maximumPlayerHealth &&!isRegenHealth)
        {
            StartCoroutine(RejenerateHealth());
        }

        PlayerDeath();

        if (currPlayerHealth !< maximumPlayerHealth)
        {
            playerHealthSlider.value = currPlayerHealth;
        }
    }
    private void Start()
    { 

        player = GameObject.FindGameObjectWithTag("Player");
    }
 
    //regenerates the players health slowly
    private IEnumerator RejenerateHealth()
    {
        isRegenHealth = true;
        while(currPlayerHealth < maximumPlayerHealth)
        {
            HealthRegen();
            yield return new WaitForSeconds(regenRate);

        }
        isRegenHealth = false;
     
    }
    public void HealthRegen()
    {
        Debug.Log("HealthRegen");

        currPlayerHealth += regenAmount;
    
    }

    IEnumerator RespawnHealth()
    {
       
        yield return new WaitForSeconds(1);

        SetPlayerHealth(maximumPlayerHealth);
        
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

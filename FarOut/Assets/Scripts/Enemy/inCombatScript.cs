using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inCombatScript : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the activating of the health bars on combat
    //
    //
    //
    //
    [SerializeField] private GameObject healthBar;
    [SerializeField] private PlayerStats playerStats;
    private int PlayerHealth, MaximumPlayerHealth;
    private void Start()
    {
        MaximumPlayerHealth = playerStats.GetMaximumHealth();
    }
    private void Update()
    {
        PlayerHealth = playerStats.GetPlayerHealth();

        if (PlayerHealth < MaximumPlayerHealth) 
        {
            healthBar.SetActive(true);
        }
        else
        {
            healthBar.SetActive(false);
        }
    }




}

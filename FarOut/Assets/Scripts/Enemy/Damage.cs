using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int maxObjecthealth = 100;
    int currentHealth = 100;
    int swordDamage = 10;
    private void Start()
    {
        currentHealth = maxObjecthealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Weapon") { CombatDamage(swordDamage); }
        
    }
    void Update()
    {
       
        if(currentHealth <= 0)
        {
            ObjectDeath();
     
        }
    }
    private void ObjectDeath() 
    {
        Destroy(this.gameObject);
    }
    public void CombatDamage(int damage) 
    {
        currentHealth = currentHealth - damage;
    
    }
}

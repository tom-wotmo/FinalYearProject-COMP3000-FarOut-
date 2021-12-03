using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int maxObjecthealth = 100;
    int currentHealth = 100;
    public Weapons weapon;
  
    private void Start()
    {
        currentHealth = maxObjecthealth;
    }
    private void OnTriggerEnter(Collider other)
    {
       int damage = weapon.weaponDamage;
        if (other.gameObject.tag == "Weapon")
        { 
            CombatDamage(damage); 
        }
        
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

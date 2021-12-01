using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerHealth = 100;
    public int currentHealth { get; private set; }
    public Stat Damage;
    public Stat Armour;

    void Awake()
    {
        currentHealth = playerHealth;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            Damaged(10);
        }
        
    }
    public void Damaged(int damage) 
    {
       // damage -= Armour.getVal();
      //  damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + damage);

        if (currentHealth <= 0) 
        {
            Damaged();
        }
    
    }
    public virtual void Damaged() 
    {
    }
}

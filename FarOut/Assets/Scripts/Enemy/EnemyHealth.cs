using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the health of enemies
    //
    //
    //
    //
    [SerializeField] public int objHealth = 100;
    [SerializeField] private NewEnemy enemy;
    private Animator enemyAnimator;
    [SerializeField] private NavMeshAgent enemyNav;
    [SerializeField] private int minHealth = 0;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Slider healthBarslider;
    
    void Start()
    {
      
        objHealth = maxHealth;

        enemyAnimator = GetComponent<Animator>();
        
    }
    //
    //
    //temporarily removed due to issues with frame calls 
    //
    IEnumerator RejenerateHealth()
    {
        int regen = enemy.amountToRegen;

        int time = enemy.timeToRegenSeconds;

        while (true)
        {
            if (objHealth < 100)
            {
                objHealth += regen;
                yield return new WaitForSeconds(time);
            }
            else { yield return true; }
        }
    }
    private void Update()
    {
        if(objHealth !< maxHealth)
        {
            healthBarslider.value = objHealth;
        }
        if(objHealth <= minHealth)
        {
            ObjectDeath();
        }
        
   
    }
   
    void ObjectDeath()
    {
        //Stops the nav mesh so the enemy doesn't follow us.
        enemyNav.isStopped = true;

        //sets all our triggers to false and allows the character to die
        enemyAnimator.ResetTrigger("isAttack");
        enemyAnimator.ResetTrigger("isIdle");
        enemyAnimator.ResetTrigger("IsRun");
        enemyAnimator.SetTrigger("isDead");

        //will destory the object
        Destroy(gameObject, 3f);

    }
 
    public int getObjHealth() { return objHealth; }
    public int getMaxObjHealth() { return maxHealth; }
    public int getMinObjHealth() { return minHealth; }

}

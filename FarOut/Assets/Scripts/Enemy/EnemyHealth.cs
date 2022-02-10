using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour
{
    public int objHealth = 100;
    public NewEnemy enemy;
    private Animator enemyAnimator;
    [SerializeField]private NavMeshAgent enemyNav;
    [SerializeField] private int minHealth = 0;
     void Start()
    {
        StartCoroutine(RejenerateHealth());

        enemyAnimator = GetComponent<Animator>();
    }
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
        ObjectDeath();
    }
    void ObjectDeath() 
    { 
        if(objHealth <= minHealth)
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
    
    }

}

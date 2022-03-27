using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;
    public Animator enemyController;
    public PlayerStats playerObj;
    int currPlayerHealth;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    private int enemyDmg;
    public NewEnemy enemyStats;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        enemyController = GetComponent<Animator>();
        enemyDmg = enemyStats.enemyDamage;

        
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

<<<<<<< Updated upstream
        if (!playerInSightRange && !playerInAttackRange) Patroling();
=======
>>>>>>> Stashed changes
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        if (!playerInAttackRange && !playerInSightRange) ResetState();

        
    }
    private void ChasePlayer()
    {
        enemyController.SetTrigger("IsRun");

        agent.SetDestination(player.position);

    }
    private void AttackPlayer() 
    {
   
        enemyController.ResetTrigger("IsRun");
        enemyController.SetTrigger("isAttack");


        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            damageAttack();

            Debug.Log("Player is being attacked");

            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void damageAttack()
    {

        int currPlayerHealth = player.GetComponent<PlayerStats>().GetPlayerHealth();

        int newHealth = currPlayerHealth - enemyDmg;

        player.GetComponent<PlayerStats>().SetPlayerHealth(newHealth);
    }
    
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
    private void ResetState()
    {
        enemyController.ResetTrigger("IsRun");
        enemyController.SetTrigger("isIdle");
    }



}

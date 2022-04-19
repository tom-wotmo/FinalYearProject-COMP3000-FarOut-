using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    //
    //
    //
    //
    //----- script to control the controlling of the enemies
    //
    //
    //
    //

    [SerializeField]private NavMeshAgent agent;
    [SerializeField]private Transform player;
    [SerializeField]private LayerMask WhatIsGround, WhatIsPlayer;
    [SerializeField]private Animator enemyController;
    [SerializeField]private PlayerStats playerObj;
    [SerializeField]private Vector3 walkPoint;
    [SerializeField]private float walkPointRange;
    [SerializeField]private int enemyDmg;
    [SerializeField]private NewEnemy enemyStats;
    [SerializeField]private float timeBetweenAttacks;
    [SerializeField]private float sightRange, attackRange;
    [SerializeField]private bool playerInSightRange, playerInAttackRange;
    int currPlayerHealth;
    bool alreadyAttacked;
    bool walkPointSet;
    Transform originalPoint;
    

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        enemyController = GetComponent<Animator>();
        enemyDmg = enemyStats.enemyDamage;
       
    }
    private void Start()
    {
        originalPoint = gameObject.transform;
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

     
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        if (!playerInAttackRange && !playerInSightRange) backToIdleState();

        
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
    private void backToIdleState()
    {
        enemyController.ResetTrigger("IsRun");
        enemyController.SetTrigger("isIdle");

        returnToPoint();
    }
    private void returnToPoint()
    {
        //send the enemy back to a certain point
        agent.SetDestination(originalPoint.position);

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public GameObject playerTransform;
    Transform target;
    NavMeshAgent agent;
    Animator enemyAnimator;
    float distance;
    public LayerMask isGround, isPlayer;
    public float attackRate = 0.1f;
    bool hasAttacked;

    public float sightRange, attackRange;
    public bool playerInRange, playerInAttackRange;
    // Start is called before the first frame update
    void Start()
    {
        target = playerTransform.transform;
        enemyAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius) 
        {
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance) 
            {
                targetFace();
            
            }
        }
        
    }
    void getLocation()
    {
        distance = Vector3.Distance(target.position, transform.position);
    }
    void targetFace() 
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion look = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    private void attackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(target);

        if (!hasAttacked)
        {
            enemyAnimator.SetBool("isWalk", true);
            enemyAnimator.SetBool("isWalk", true);

            Debug.Log("You are taking damage");

            hasAttacked = true;

            Invoke(nameof(ResetAttack), attackRate);
        }
    }
    private void ResetAttack()
    {
        hasAttacked = false;
        Debug.Log("Resetting Attack");
    }
}

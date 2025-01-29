using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour 
{
    public NavMeshAgent agent;

    public Transform player;
    public float health;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake() 
    {
        player = GameObject.Find("Player Character").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() 
    {
        if (health <= 0) DestroyEnemy();
        OnDrawGizmosSelected();

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

    }
    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude <1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //calc rand point in range
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///attack code here


            ///
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;


    }
    private void DestroyEnemy()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnDrawGizmosSelected() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, attackRange);
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
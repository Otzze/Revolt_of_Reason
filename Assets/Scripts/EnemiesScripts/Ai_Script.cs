using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;

public class Ai_Script : MonoBehaviour
{
    public NavMeshAgent agento;
    public Transform player;
    public LayerMask IsGround,IsPlayer;
    public float health;
    
    // Patroling

    public Vector3 walkPoint; 
    bool walkpointSet;
    public float walkPointRange;
    
    // Attacking 
    public float timeBetweenAttacks; 
    bool _alreadyAttacked;
    public GameObject projectile;
    
    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
       // player = GameObject.Find("Player").transform;
        agento = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, IsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, IsPlayer);
        
        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkpointSet) SearchWalkPoint();

        if (walkpointSet)
            agento.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkpointSet = false;
    }

    private void SearchWalkPoint()
    {
        // Calculate random point in range 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, IsGround))
            walkpointSet = true;
    }

    private void ChasePlayer()
    {
        foreach (GameObject thePlayer in SpawnPlayers.Instance.PlayerObject)
        {
            if (Vector3.Distance(thePlayer.transform.position, transform.position) <= sightRange)
            {
                agento.SetDestination(thePlayer.transform.position);
            }
        }
        
    }

    private void AttackPlayer()
    {
        // Make sure enemy doesn't move
        agento.SetDestination(transform.position);
        
        transform.LookAt(player);

        if (!_alreadyAttacked)
        {
            // Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 1520f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            
            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if(health <= 0) Invoke(nameof(DestroyEnemy),.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.magenta;
       Gizmos.DrawWireSphere(transform.position,attackRange);
       Gizmos.color = Color.cyan;
       Gizmos.DrawWireSphere(transform.position,sightRange);
    }
}
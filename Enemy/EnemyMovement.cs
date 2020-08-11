using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    PlayerHealth playerHealth;
    [SerializeField] private EnemyStatConfig statConfig;

    //public EnemyStatConfig config;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Start()
    {
        agent.speed = statConfig.speed;
    }
    
    void Update()
    {
        if (playerHealth.PlayerIsAlive)
            FollowPlayer();

    }

    void FollowPlayer()
    {
        agent.SetDestination(target.position);
    }
}

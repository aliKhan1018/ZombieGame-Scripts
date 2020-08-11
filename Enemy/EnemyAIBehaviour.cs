using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIBehaviour : MonoBehaviour
{

	// public float sightRadius = 2.5f;
	// public bool playerInRange;
	// public SphereCollider sightSphere;
	// public float wanderRadius = 5f;

	// Ray m_rayForward, m_rayLeft, m_rayRight;
	// float rayLength = 2f;

	// NavMeshAgent agent;

	// private void Awake()
	// {
	// 	agent = GetComponent<NavMeshAgent>();
	// }
	

	// public enum State
	// {
	// 	Wander,
	// 	Chase,
	// 	Attack
	// }

	// public State state;

	// private void Start()
	// {

	// 	state = State.Wander;
	// }

	// private void Update()
	// {
	// 	m_rayForward.origin = m_rayLeft.origin = m_rayRight.origin = transform.position;
	// 	m_rayForward.direction = transform.forward;

	// 	RaycastHit hit;

	// 	if(Physics.Raycast(m_rayForward, out hit, rayLength))
	// 	{
	// 		print(hit.collider.tag);
	// 	}


	// 	Wander();
	// }

	// private void Chase()
	// {
	// 	throw new NotImplementedException();
	// }

	// private void Wander()
	// {
	// 	//agent.SetDestination(moveToPoint);
	// }

	// private void OnDrawGizmos()
	// {
	// 	Gizmos.DrawRay(m_rayForward);
	// 	Gizmos.DrawRay(m_rayLeft);
	// 	Gizmos.DrawRay(m_rayRight);
	// }
}

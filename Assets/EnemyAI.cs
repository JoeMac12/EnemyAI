using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyAI : MonoBehaviour
{
	public NavMeshAgent agent;
	public Transform player;
	public Transform[] patrolPoints;
	public AIState currentState;
	private int patrolPointIndex = 0;

	public float sightRange = 10f;
	public float attackRange = 2f;
	public float loseSightRange = 15f;
	public float searchDuration = 5f;
	public Vector3 lastKnownPosition;
	private float searchTimer;

	public TextMeshProUGUI stateText;
	private float distanceToPlayer;

	public enum AIState { Patrolling, Chasing, Searching, Attacking, Retreating } // States

	void Start() // Load NavMesh and set to patrolling
	{
		agent = GetComponent<NavMeshAgent>();
		currentState = AIState.Patrolling;
	}

	void Update() // Updating and checking
	{
		distanceToPlayer = Vector3.Distance(player.position, transform.position);

		UpdateStateText();
		StateManager();

		if (currentState != AIState.Attacking && currentState != AIState.Searching)
		{
			EnemySight();
		}

		HandleTransitions();
	}

	private void UpdateStateText() // For updating the UI text of state changes
	{
		stateText.text = currentState.ToString();
		switch (currentState)
		{
			case AIState.Patrolling:
				stateText.color = Color.green;
				break;
			case AIState.Chasing:
				stateText.color = new Color32(255, 165, 0, 255);
				break;
			case AIState.Searching:
				stateText.color = Color.yellow;
				break;
			case AIState.Attacking:
				stateText.color = Color.red;
				break;
			case AIState.Retreating:
				stateText.color = Color.blue;
				break;
		}
	}

	private void StateManager() // Manging and switching all states
	{
		switch (currentState)
		{
			case AIState.Patrolling:
				Patrol();
				break;
			case AIState.Chasing:
				Chase();
				break;
			case AIState.Searching:
				Search();
				break;
			case AIState.Attacking:
				Attack();
				break;
			case AIState.Retreating:
				Retreat();
				break;
		}
	}

	private void EnemySight() // Checking enemy sight
	{
		if (distanceToPlayer <= sightRange) // Player was seen and begin chasing
		{
			ChangeState(AIState.Chasing);
		}
		else if (currentState == AIState.Chasing && distanceToPlayer > loseSightRange) // Out of chasing range
		{
			ChangeState(AIState.Searching);
		}
	}

	private void HandleTransitions() // Handling transitions between some states
	{
		if (currentState == AIState.Chasing && distanceToPlayer <= attackRange) // In attack range
		{
			ChangeState(AIState.Attacking);
		}
		else if (currentState == AIState.Attacking && distanceToPlayer > attackRange) // No longer in attack range
		{
			ChangeState(AIState.Chasing);
		}
	}

	void Patrol()
	{
	}

	void Chase()
	{
	}

	void Search()
	{
	}

	void Attack() // No attacking needed for project
	{
	}

	void Retreat()
	{
	}

	void ChangeState(AIState newState) // Changing states and don't make enemy move in attacking or searching states
	{
		if (newState == AIState.Searching || newState == AIState.Attacking)
		{
			agent.isStopped = true;
		}
		else
		{
			agent.isStopped = false;
		}

		currentState = newState;
	}
}

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
}

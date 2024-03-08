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
}

using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private EnemyState _currentState;

    public Transform[] patrolPoints;

    public Transform EnemyEye;
    public float sightRadius;
    public float sightDistance;

    public NavMeshAgent agent;

    [HideInInspector] public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _currentState = new EnemyPatrolState(this);
        _currentState.OnStateEnter();
    }

    // Update is called once per frame
    void Update()
    { _currentState.OnStateUpdate(); }

    public void ChangeState(EnemyState state)
    {
        _currentState.OnStateExit();
        _currentState = state;
        _currentState.OnStateEnter();
    }
}

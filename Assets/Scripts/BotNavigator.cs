using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class BotNavigator : MonoBehaviour
{
    public NavMeshAgent BotNavMeshAgent;
    [SerializeField] private Animator botAnimator;
    [Header("Actual State")]
    [SerializeField] private State currentState;
    [Space]
    [SerializeField] private State idleState;
    [SerializeField] private State patrolState;
    [SerializeField] private State fireState;
    [Space]
    [SerializeField] private Transform[] wayPoints;

    private void Start()
    {
        SetState(idleState);
    }

    public void GoToNextWayPoint()
    {
        BotNavMeshAgent.SetDestination(wayPoints[Random.Range(0, wayPoints.Length)].position);
    }

    public void FireToTarget()
    {
        SetState(fireState);
    }

    private void FixedUpdate()
    {
        if (!currentState.isFinished)
        {
            currentState.Run();
        }
        else
        {
            SetState(patrolState);
        }
    }

    public void SetState(State state)
    {
        currentState = Instantiate(state);
        currentState.BotNavigator = this;
        currentState.BotAnimator = botAnimator;

        currentState.Init();
    }
}
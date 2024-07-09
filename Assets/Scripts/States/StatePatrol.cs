using UnityEngine;

[CreateAssetMenu]

public class StatePatrol : State
{
    public override void Init()
    {
        SetAnimation(WALKING);
    }

    public override void Run()
    {
        if (isFinished) return;

        if (BotNavigator.BotNavMeshAgent.remainingDistance < 0.1f)
        {
            BotNavigator.GoToNextWayPoint();
            isFinished = true;
        }
    }
}
using UnityEngine;

[CreateAssetMenu]

public class StateFire : State
{
    [SerializeField] private float aimTime;
    private float countdown;

    public override void Init()
    {
        BotNavigator.BotNavMeshAgent.isStopped = true;
        countdown = aimTime;
        SetAnimation(FIRE);
    }

    public override void Run()
    {
        if (isFinished) return;

        AimAndFire();
    }

    private void AimAndFire()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Debug.Log("Player is shooted");
            isFinished = true;
        }
    }
}

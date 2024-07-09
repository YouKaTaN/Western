using UnityEngine;

[CreateAssetMenu]

public class StateIdle : State
{
    [SerializeField] private float waitingTime;
    private float countdown;

    public override void Init()
    {
        countdown = waitingTime;
        SetAnimation(IDLE);
    }

    public override void Run()
    {
        if (isFinished) return;

        Waiting();
    }

    private void Waiting()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            isFinished = true;
        }
    }
}

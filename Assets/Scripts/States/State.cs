using UnityEngine;

public abstract class State : ScriptableObject
{
    public bool isFinished { get; protected set; }

    public static readonly string IDLE = "idle";
    public static readonly string WALKING = "walking";
    public static readonly string FIRE = "fire";

    private readonly string[] animations = new string[] {IDLE, WALKING, FIRE};

    [HideInInspector] public BotNavigator BotNavigator;
    [HideInInspector] public Animator BotAnimator;

    public virtual void Init() 
    {
        BotAnimator.speed = 1;
    }

    public abstract void Run();

    public virtual void SetAnimation(string name_animation)
    {
        foreach (string animation in animations)
        {
            BotAnimator.SetBool(animation, false);
        }
        BotAnimator.SetBool(name_animation, true);
    }
}

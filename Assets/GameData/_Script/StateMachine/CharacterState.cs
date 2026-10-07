using UnityEngine;

public abstract class CharacterState
{
    protected StateMachine stateMachine;

    protected Rigidbody2D rb;
    protected Animator anim;

    protected float stateTimer;
    protected string animBoolName;
    protected bool triggerCalled;
    
    public CharacterState(StateMachine stateMachine, string animBoolName)
    {
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        anim.SetBool(animBoolName,true);
        triggerCalled = false;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        UpdateAnimationParameters();
    }
    public virtual void Exit() => anim.SetBool(animBoolName, false);
    public void AnimationTrigger()=> triggerCalled = true;
    public virtual void UpdateAnimationParameters() { }

}

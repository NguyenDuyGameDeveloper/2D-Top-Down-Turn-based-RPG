public class StateMachine
{
    public CharacterState currentState {  get; private set; }
    public bool canChangeState = true;
    public void Initialize(CharacterState startState)
    {
        currentState = startState;
        currentState.Enter();
    }
    public void ChangeState(CharacterState newState)
    {
        if (!canChangeState) return;

        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    public void UpdateActiveState() => currentState.Update();
    public void SwitchOffStateMachine() => canChangeState = false;
}

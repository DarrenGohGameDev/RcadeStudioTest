using UnityEngine;

public abstract class RunningDogState : BaseState<RunningDogStateMachine.ERunningDogState>
{
    protected RunningDogInteractionContext context;

    public RunningDogState(RunningDogInteractionContext context,RunningDogStateMachine.ERunningDogState 
    stateKey) : base(stateKey)
    {
        this.context = context;
    }
}

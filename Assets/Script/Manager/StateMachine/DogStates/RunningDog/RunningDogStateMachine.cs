using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class RunningDogStateMachine : StateManager<RunningDogStateMachine.ERunningDogState>
{
    public enum ERunningDogState
    {
        Idle,
        Running,
        CatchingBreath,
    }

    private RunningDogInteractionContext _interactionContext;

    private void Awake()
    {
        ValidateConstraints();
        _interactionContext = new RunningDogInteractionContext(runningDogController);
        InitializeStates();
    }

    [SerializeField] private RunningDogController runningDogController;

    private void InitializeStates()
    {
        states.Add(ERunningDogState.Idle,new RunningDogIdleState(_interactionContext,ERunningDogState.Idle));
        states.Add(ERunningDogState.Running, new RunningDogRunningState(_interactionContext,ERunningDogState.Running));
        states.Add(ERunningDogState.CatchingBreath, new RunningDogCatchingBreathState(_interactionContext,ERunningDogState.CatchingBreath));
        currentState = states[ERunningDogState.Idle];
    }

    private void ValidateConstraints()
    {
        Assert.IsNotNull(runningDogController, "Dog controller is empty");
    }
}

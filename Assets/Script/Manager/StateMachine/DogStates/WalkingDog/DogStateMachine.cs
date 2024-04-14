using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class DogStateMachine : StateManager<DogStateMachine.EDogState>
{
    public enum EDogState
    { 
        Idle,
        Walking,
    }

    private DogInteractionContext _interactionContext;

    private void Awake()
    {
        ValidateConstraints();
        _interactionContext = new DogInteractionContext(dogController);
        IntializeStates();
    }

    [SerializeField] private DogController dogController;

    private void IntializeStates()
    {
        states.Add(EDogState.Idle, new DogIdleState(_interactionContext, EDogState.Idle));
        states.Add(EDogState.Walking, new DogWalkingState(_interactionContext,EDogState.Walking));
        currentState = states[EDogState.Idle];
    }

    private void ValidateConstraints()
    {
        Assert.IsNotNull(dogController,"Dog controller is empty");
    }
}

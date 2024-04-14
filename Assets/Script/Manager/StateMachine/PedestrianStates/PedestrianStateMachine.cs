using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PedestrianStateMachine : StateManager<PedestrianStateMachine.EPedestrianState>
{
    public enum EPedestrianState
    {
        Idle,
        Walking,
        Fleeing,
        Hidding,
    }

    private PedestrianInteractionContext _interactionContext;

    private void Awake()
    {
        ValidateConstraints();
        _interactionContext = new PedestrianInteractionContext(pedestrianController);
        IntializeStates();
    }

    [SerializeField] private PedestrianController pedestrianController;

    private void IntializeStates()
    {
        states.Add(EPedestrianState.Idle, new PedestrianIdleState(_interactionContext, EPedestrianState.Idle));
        states.Add(EPedestrianState.Walking , new PedestrianWalkingState(_interactionContext,EPedestrianState.Walking));
        states.Add(EPedestrianState.Fleeing, new PedestrianFleeingState(_interactionContext,EPedestrianState.Fleeing));
        states.Add(EPedestrianState.Hidding, new PedestrianHideState(_interactionContext, EPedestrianState.Hidding));
        currentState = states[EPedestrianState.Idle];
    }

    private void ValidateConstraints()
    {
        Assert.IsNotNull(pedestrianController,"Pedestrian controller is empty");
    }
}

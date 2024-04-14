using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogIdleState : DogState
{
    public DogIdleState(DogInteractionContext context, DogStateMachine.EDogState estate) : base
        (context, estate)
    {
        DogInteractionContext _context = context;
    }

    public override void EnterState()
    {
        context.dogController.SetCurrentPosition();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        
    }

    public override DogStateMachine.EDogState GetNextState()
    {
        if (GameManager.instance.stateMachine.currentState.ToString() == GameStateMachine.EGameState.InGameState.ToString())
        {
            return DogStateMachine.EDogState.Walking;
        }
        return stateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {

    }
    public override void OnTriggerStay(Collider other)
    {

    }

    public override void OnTriggerExit(Collider other)
    {

    }
}

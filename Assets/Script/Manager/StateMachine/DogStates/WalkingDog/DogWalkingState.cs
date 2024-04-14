using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogWalkingState : DogState
{
    public DogWalkingState(DogInteractionContext context, DogStateMachine.EDogState estate) : base(context, estate)
    {
        DogInteractionContext _context = context;
    }
    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        context.dogController.MoveToNextWaypoint();
    }

    public override DogStateMachine.EDogState GetNextState()
    {

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

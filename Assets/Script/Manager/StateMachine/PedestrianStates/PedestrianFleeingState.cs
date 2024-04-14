using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianFleeingState : PedestrianState
{
    public PedestrianFleeingState(PedestrianInteractionContext context,PedestrianStateMachine.EPedestrianState estate) : base
        (context, estate)
    {
        PedestrianInteractionContext _context = context;
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        context.pedestrianController.FleeBackToPrevWaypoint();
    }

    public override PedestrianStateMachine.EPedestrianState GetNextState()
    {
        if(context.pedestrianController.fleed)
        {
            return PedestrianStateMachine.EPedestrianState.Walking;
        }

        if(context.pedestrianController.hideFromDog)
        {
            return PedestrianStateMachine.EPedestrianState.Hidding;
        }
        return stateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dog"))
        {
            Debug.Log("near dog when fleeing");
            context.pedestrianController.hideFromDog = true;
        }
    }
    public override void OnTriggerStay(Collider other)
    {

    }

    public override void OnTriggerExit(Collider other)
    {

    }
}

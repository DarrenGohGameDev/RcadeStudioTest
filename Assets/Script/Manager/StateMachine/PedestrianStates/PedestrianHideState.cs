using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianHideState : PedestrianState
{
    public PedestrianHideState(PedestrianInteractionContext context,PedestrianStateMachine.EPedestrianState estate) : base
    (context, estate)
    {
        PedestrianInteractionContext _context = context;
    }

    public override void EnterState()
    {
        
    }

    public override void ExitState()
    {
        context.pedestrianController.hideDuration = context.pedestrianController.MaxHideDuration;
        context.pedestrianController.hideFromDog = false;
    }

    public override void UpdateState()
    {
        context.pedestrianController.HideFromDogs();
    }

    public override PedestrianStateMachine.EPedestrianState GetNextState()
    {
        if (context.pedestrianController.hideDuration < 0)
        {
            context.pedestrianController.agent.isStopped = false;
            return PedestrianStateMachine.EPedestrianState.Walking;
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

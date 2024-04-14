using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianIdleState : PedestrianState
{
    public PedestrianIdleState(PedestrianInteractionContext context, PedestrianStateMachine.EPedestrianState estate) : base
    (context, estate)
    {
        PedestrianInteractionContext _context = context;
    }

    public override void EnterState()
    {
        context.pedestrianController.SetCurrentPosition();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {

    }

    public override PedestrianStateMachine.EPedestrianState GetNextState()
    {
        if(GameManager.instance.stateMachine.currentState.ToString() == GameStateMachine.EGameState.InGameState.ToString()) 
        {
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

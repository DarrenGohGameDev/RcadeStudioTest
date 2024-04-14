using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianWalkingState : PedestrianState
{
    public PedestrianWalkingState(PedestrianInteractionContext context,PedestrianStateMachine.EPedestrianState 
    estate) : base(context, estate)
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
        context.pedestrianController.MoveToNextWaypoint();
    }

    public override PedestrianStateMachine.EPedestrianState GetNextState()
    {
        if(context.pedestrianController.dogIsNear)
        {
            return PedestrianStateMachine.EPedestrianState.Fleeing;
        }
        return stateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dog"))
        {
            if (other.ClosestPoint(other.transform.position).z > 0)
            {
                context.pedestrianController.nearDogIsFront = true;
            }
            else
            {
                context.pedestrianController.nearDogIsFront = false;
            }
            context.pedestrianController.dogIsNear = true;
        }
    }

    public override void OnTriggerStay(Collider other)
    {

    }

    public override void OnTriggerExit(Collider other)
    {

    }
}

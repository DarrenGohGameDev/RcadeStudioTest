using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDogRunningState : RunningDogState
{

    public RunningDogRunningState(RunningDogInteractionContext context , RunningDogStateMachine.ERunningDogState estate) : base
        (context , estate)
    {
        RunningDogInteractionContext _context = context;
    }

    public override void EnterState()
    {
        context.runningDogController.agent.isStopped = false;
    }

    public override void ExitState()
    {
        context.runningDogController.agent.isStopped = true;
    }

    public override void UpdateState()
    {
        context.runningDogController.MoveToNextWaypoint();
    }

    public override RunningDogStateMachine.ERunningDogState GetNextState()
    {
        if (context.runningDogController.stamina <= 0)
        {

            return RunningDogStateMachine.ERunningDogState.CatchingBreath;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDogIdleState : RunningDogState
{
    public RunningDogIdleState(RunningDogInteractionContext context,RunningDogStateMachine.ERunningDogState estate) : base
        (context, estate)
    {
        RunningDogInteractionContext _context = context;
    }

    public override void EnterState()
    {
        context.runningDogController.SetCurrentPosition();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {

    }

    public override RunningDogStateMachine.ERunningDogState GetNextState()
    {
        if (GameManager.instance.stateMachine.currentState.ToString() == GameStateMachine.EGameState.InGameState.ToString())
        {
            return RunningDogStateMachine.ERunningDogState.Running;
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

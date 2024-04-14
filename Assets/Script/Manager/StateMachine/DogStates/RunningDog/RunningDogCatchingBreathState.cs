using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDogCatchingBreathState : RunningDogState
{
    public RunningDogCatchingBreathState(RunningDogInteractionContext context, RunningDogStateMachine.ERunningDogState estate) : base
    (context, estate)
    {
        RunningDogInteractionContext _context = context;
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
        context.runningDogController.RegenStamina();
    }

    public override RunningDogStateMachine.ERunningDogState GetNextState()
    {
        if (context.runningDogController.stamina >= context.runningDogController.maxStamina)
        {
            context.runningDogController.stamina = context.runningDogController.maxStamina;
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

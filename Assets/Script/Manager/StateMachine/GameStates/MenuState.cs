using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : GameState
{
    public MenuState(GameStateInteractionContext context, GameStateMachine.EGameState estate) : base
        (context, estate)
    {

    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {

    }

    public override GameStateMachine.EGameState GetNextState()
    {
        if(context.gameStateController.uiManager.finishCd)
        {
            return GameStateMachine.EGameState.InGameState;
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

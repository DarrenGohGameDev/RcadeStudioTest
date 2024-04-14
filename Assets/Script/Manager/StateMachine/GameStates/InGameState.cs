using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameState : GameState
{
    public InGameState(GameStateInteractionContext context, GameStateMachine.EGameState estate) : base
        (context, estate)
    {
        GameStateInteractionContext _context = context;
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

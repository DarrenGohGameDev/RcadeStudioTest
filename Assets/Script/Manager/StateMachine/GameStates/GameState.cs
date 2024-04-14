using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState : BaseState<GameStateMachine.EGameState>
{
    protected GameStateInteractionContext context;

    public GameState(GameStateInteractionContext context, GameStateMachine.EGameState 
        stateKey) : base(stateKey)
    {
        this.context = context; 
    }
}
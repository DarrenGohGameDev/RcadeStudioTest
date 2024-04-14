using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameStateMachine : StateManager<GameStateMachine.EGameState>
{
    public enum EGameState
    {
        MenuState,
        InGameState,
    }

    private GameStateInteractionContext _interactionContext;

    private void Awake()
    {
        ValidateConstraints();
        _interactionContext = new GameStateInteractionContext(gameStateController);
        IntializeStates();
    }

    [SerializeField] private GameStateController gameStateController;

    private void IntializeStates()
    {
        states.Add(EGameState.MenuState, new MenuState(_interactionContext,EGameState.MenuState));
        states.Add(EGameState.InGameState, new InGameState(_interactionContext, EGameState.InGameState));
        currentState = states[EGameState.MenuState];
    }

    private void ValidateConstraints()
    {
        Assert.IsNotNull(gameStateController, "Game State controller is empty");
    }
}

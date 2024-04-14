using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateInteractionContext 
{
    [SerializeField] private GameStateController _gameStateController;

    public GameStateInteractionContext(GameStateController gameStateController)
    {
        _gameStateController = gameStateController;
    }

    public GameStateController gameStateController => _gameStateController;
}

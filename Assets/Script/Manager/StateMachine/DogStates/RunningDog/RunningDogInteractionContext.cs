using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDogInteractionContext 
{

    [SerializeField] private RunningDogController _runningDogController;

    public RunningDogInteractionContext(RunningDogController runningDogController)
    {
        _runningDogController = runningDogController;
    }

    public RunningDogController runningDogController => _runningDogController;
}

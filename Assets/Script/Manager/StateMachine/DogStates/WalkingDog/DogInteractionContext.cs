using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInteractionContext 
{
    [SerializeField] private DogController _dogController;

    public DogInteractionContext(DogController dogController)
    {
        _dogController = dogController;
    }

    public DogController dogController => _dogController;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianInteractionContext 
{
    [SerializeField] private PedestrianController _pedestrianController;

    public PedestrianInteractionContext(PedestrianController pedestrianController)
    {
        _pedestrianController = pedestrianController;
    }

    public PedestrianController pedestrianController => _pedestrianController;
}

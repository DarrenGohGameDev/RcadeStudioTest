using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PedestrianState : BaseState<PedestrianStateMachine.EPedestrianState>
{
    protected PedestrianInteractionContext context;

    public PedestrianState(PedestrianInteractionContext context,PedestrianStateMachine.EPedestrianState 
    stateKey) : base(stateKey)
    {
        this.context = context;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DogState : BaseState<DogStateMachine.EDogState>
{
    protected DogInteractionContext context;

    public DogState(DogInteractionContext context,DogStateMachine.EDogState
        stateKey) : base(stateKey)
    {
        this.context = context;
    }
}

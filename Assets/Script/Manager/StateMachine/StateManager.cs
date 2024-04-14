using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState,BaseState<EState>> states = new Dictionary<EState, BaseState<EState>>();

    public BaseState<EState> currentState { get; protected set; }

    protected bool isTransitioningState = false;

    // Start is called before the first frame update
    void Start()
    {
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        EState nextStateKey = currentState.GetNextState();

        if(!isTransitioningState && nextStateKey.Equals(currentState.stateKey)) 
        {
            currentState.UpdateState();
        }
        else if(!isTransitioningState)
        {
            TransitionToState(nextStateKey);
        }

        currentState.UpdateState();
    }

    public void TransitionToState(EState stateKey)
    {
        isTransitioningState = true;
        currentState.ExitState();
        currentState = states[stateKey];
        currentState.EnterState();
        isTransitioningState = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
}

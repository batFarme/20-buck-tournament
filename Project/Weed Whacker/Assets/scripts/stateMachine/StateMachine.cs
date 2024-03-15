using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<Estate> : MonoBehaviour where Estate : Enum
{
    Dictionary<Estate, BaseState<Estate>> States = new Dictionary<Estate, BaseState<Estate>>();
    BaseState<Estate> CurrentState;

    bool isTransitioningState = false;

    void Start()
    {
        CurrentState.EnterState();
    }

    void Update()
    {
        Estate nextStateKey = CurrentState.GetNextState(); 

        if (!isTransitioningState)
        {
            if (nextStateKey.Equals(CurrentState.StateKey))  // a check like this running every frame seems unoptimal... im just copying off the video for now but i should come back and see if it cant be optimized  TO-DO-FLAG-1
            {
                CurrentState.UpdateState();
            }
            else
            {
                TransitionToState(nextStateKey);
            }
        }
    }

    public void TransitionToState(Estate stateKey)
    {
        isTransitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
        isTransitioningState = false; 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CurrentState.OnTriggerEnter(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        CurrentState.OnTriggerExit(collision);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        CurrentState.OnTriggerStay(collision);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<Estate> : MonoBehaviour where Estate : Enum
{
    Dictionary<Estate, BaseState<Estate>> StateDict = new Dictionary<Estate, BaseState<Estate>>();
    BaseState<Estate> CrntState;

    public bool isTransitioningState = false;

    void Start()
    {
        CrntState.EnterState();
    }

    void Update()
    {
        Estate nextStateKey = CrntState.GetNextState(); 

        if (!isTransitioningState)
        {
            if (nextStateKey.Equals(CrntState.StateKey))  // a check like this running every frame seems unoptimal... 
            {                                             // im just copying off the video for now but i should come 
                CrntState.UpdateState();                  // back and see if it cant be optimized  TO-DO-FLAG-1
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
        CrntState.ExitState();
        CrntState = StateDict[stateKey];
        CrntState.EnterState();
        isTransitioningState = false; 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CrntState.OnTriggerEnter(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        CrntState.OnTriggerExit(collision);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        CrntState.OnTriggerStay(collision);
    }
}

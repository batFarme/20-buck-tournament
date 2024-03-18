using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState<Estate> where Estate : Enum
{
    public BaseState(Estate key)
    {
        StateKey = key;
    }

    public Enum StateKey { get; set; }
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract Estate GetNextState();
    public abstract void OnTriggerEnter(Collider2D collision);
    public abstract void OnTriggerExit(Collider2D collision);   
    public abstract void OnTriggerStay(Collider2D collision);
}

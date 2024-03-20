using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState<Estate> where Estate : Enum
{
    protected GameObject selfObject;
    public BaseState(Estate key, GameObject SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
    }

    public Enum StateKey { get; set; }
    public Estate StateIWantToBe { get; set; }
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract Estate GetNextState();  //this works in tandem with the base statemachine script to 
    public abstract void OnTriggerEnter(Collider2D collision);
    public abstract void OnTriggerExit(Collider2D collision);   
    public abstract void OnTriggerStay(Collider2D collision);
}

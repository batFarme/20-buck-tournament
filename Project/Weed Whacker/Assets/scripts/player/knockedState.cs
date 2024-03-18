using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class knockedState : BaseState<playerScript.PlayerStates> // this gives an error for some reason....
{
    public knockedState(playerScript.PlayerStates key) : base(key)
    {
        StateKey = key;
    }
    
    public override void EnterState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override playerScript.PlayerStates GetNextState()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        
    }

    public override void OnTriggerExit(Collider2D collision)
    {
        
    }

    public override void OnTriggerStay(Collider2D collision)
    {
        
    }

    public override void UpdateState()
    {
        
    }

}

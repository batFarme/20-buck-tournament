using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadState : BaseState<playerScript.States>
{
    public deadState(playerScript.States key) : base(key)
    {
        StateKey = key;
        StateIWantToBe = key;
    }
    public override void EnterState()
    {
        
    }

    public override void ExitState()
    {
        
    }

    public override playerScript.States GetNextState()
    {
        return StateIWantToBe;
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

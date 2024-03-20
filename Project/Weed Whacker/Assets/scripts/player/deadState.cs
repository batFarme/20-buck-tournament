using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadState : BaseState<playerScript.States>
{

    public deadState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
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

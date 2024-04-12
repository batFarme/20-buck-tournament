using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadState : BaseState<playerScript.States>
{
    public playerScript theMainScriptSWE; //somehow give deadState.cs a reference to the current instance of playerScript...
    public deadState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
    }
    public override void EnterState()
    {
        theMainScriptSWE.myAnimator.SetTrigger("wasKillded");
        theMainScriptSWE.tellStalkerToFuckOff.Invoke();
    }

    public override void UpdateState()
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
}

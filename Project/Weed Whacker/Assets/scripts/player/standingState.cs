using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class standingState : BaseState<playerScript.States>, IWalkBehavior
{
    //references
    private GameObject playerObject;

    public standingState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
    }

    public override void EnterState()
    {
        Debug.Log("yep, it works!");
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

    public void movement(float speed, Vector2 direction) 
    { 

    }
}

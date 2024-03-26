using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class knockedState : BaseState<playerScript.States>, IWalkBehavior
{
    //references

    //internal handling
    private int rezCount = 0; // uhh... still undecided if this should be counted in seconds or frames..... oh well!
    

    public knockedState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
    }
    
    public override void EnterState()
    {
        //rezCount = playerScript.rezCountLength;  //need to figure ou thow to findthe player gameobject and reference that in htis script
        // play an initial drop animation
        // play a sound effect
        // update this player's hud to portray knocked state
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
        // if collision is tagged player, then start counting down 
    }
    public void movement(float speed, Vector2 direction)
    {

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class knockedState : BaseState<playerScript.States>, IWalkBehavior
{
    //references
    private playerScript theMainScriptSWE;
    private Rigidbody2D myRigidBody;
    private Animator animator;

    //internal handling
    private int rezCount = 0; // uhh... still undecided if this should be counted in seconds or frames..... oh well!
    

    public knockedState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
        myRigidBody = selfObject.GetComponent<Rigidbody2D>();
        theMainScriptSWE = selfObject.GetComponent<playerScript>();
        animator = selfObject.GetComponent<Animator>();
    }
    
    public override void EnterState()
    {
        theMainScriptSWE.myAnimator.SetTrigger("wasKnocked");
        //rezCount = playerScript.rezCountLength;  //need to figure ou thow to findthe player gameobject and reference that in htis script
        // play an initial drop animation
        // play a sound effect
        // update this player's hud to portray knocked state
        //theMainScriptSWE.tellStalkersToGoAway();
    }

    public override void UpdateState()
    {
        movement(theMainScriptSWE.knockedMoveSpeed, theMainScriptSWE.move.ReadValue<Vector2>());
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
        if (collision.gameObject.layer == selfObject.layer) //rezzing; code does not account for more than two players, but that shouldnt be an issue :shrug:
        {
            theMainScriptSWE.myAnimator.SetTrigger("teammateTouchingMe");
        }
    }

    public override void OnTriggerExit(Collider2D collision)
    {
        if (collision.gameObject.layer == selfObject.layer)
        {
            theMainScriptSWE.myAnimator.SetTrigger("teammateNoLongerTouchingMe");
        }

    }

    public override void OnTriggerStay(Collider2D collision)
    {
        // if collision is tagged player, then start counting down 
    }
    public void movement(float speed, Vector2 direction)
    {
        //Debug.Log(direction);
        myRigidBody.velocity = direction * speed;
        /*
        if (myRigidBody.velocity != Vector2.zero)
        {

        }
        selfObject.transform.localScale = new Vector3(1, selfObject.transform.localScale.y, selfObject.transform.localScale.z);
        */
    }

}

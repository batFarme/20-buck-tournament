using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class standingState : BaseState<playerScript.States>
{
    //references
    private playerScript playerScript;
    private Rigidbody2D myRigidBody;
    private Animator animator;

    //internal control variables
 
    public standingState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
        myRigidBody = selfObject.GetComponent<Rigidbody2D>();
        playerScript = selfObject.GetComponent<playerScript>();
        animator = selfObject.GetComponent<Animator>();
        playerScript.attack.performed += context => performAttack(context);
    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        playerScript.movement(playerScript.moveSpeed, playerScript.move.ReadValue<Vector2>());
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

    public void getKnocked()
    {
        StateIWantToBe = playerScript.States.knocked;
    }

    public void fuckingDie()
    {
        StateIWantToBe = playerScript.States.dead;
    }

    public void performAttack(InputAction.CallbackContext context)
    {
        animator.SetTrigger("attackPressed");
        Debug.Log("attack called! animator's attack parameter is now " + animator.parameters.GetValue(1));
    }
}

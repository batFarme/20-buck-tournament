using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class standingState : BaseState<playerScript.States>, IWalkBehavior
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
        movement(playerScript.moveSpeed, playerScript.move.ReadValue<Vector2>());
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

    public void movement(float speed, Vector2 direction) 
    {
        myRigidBody.velocity = direction * speed;   // also later, if possible, change this entirely so player accelerates and decelerates rather than just starting and stopping TO-DO-FLAG-3 

        if (direction != Vector2.zero)             // WHOOOOOOO BOY this needs to be HELLA optimized, aint no way having this set every frame is healthy :skull:
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false); 
        }
        //sprite flipping
        if (direction.x != 0)  //if player is currently inputting a move direction
        {
            if (direction.x < 0)
            {
                selfObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else 
            {
                selfObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        {

        }
        /*
        if (myRigidBody.velocity != Vector2.zero)
        {

        }
        selfObject.transform.localScale = new Vector3(1, selfObject.transform.localScale.y, selfObject.transform.localScale.z);
        */
    }

    public void performAttack(InputAction.CallbackContext context)
    {
        animator.SetTrigger("attackPressed");
        Debug.Log("attack called! animator's attack parameter is now " + animator.parameters.GetValue(1));
    }
}

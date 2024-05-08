using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class standingState : BaseState<playerScript.States>
{
    //references
    private playerScript playersScript;
    private Rigidbody2D myRigidBody;
    private Animator animator;

    //gamestate shit


    //internal control variables
 
    public standingState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
        myRigidBody = selfObject.GetComponent<Rigidbody2D>();
        playersScript = selfObject.GetComponent<playerScript>();
        animator = selfObject.GetComponent<Animator>();
    }

    public override void EnterState()
    {
        playersScript.notTheBallsTheManager.GetComponent<GameManager>().addPlayerToAlivePool(selfObject);
        playersScript.attack.performed += performAttack; //be mindful that standing can be entered from the knocked state too; anything to do with leaving the limbo state should be done in the limbo state's exitState function.
    }

    public override void UpdateState()
    {
        playersScript.movement(playersScript.moveSpeed, playersScript.move.ReadValue<Vector2>());
    }

    public override void ExitState()
    {
        playersScript.attack.performed -= performAttack;
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

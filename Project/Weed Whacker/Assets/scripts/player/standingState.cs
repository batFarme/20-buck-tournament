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

    //internal control variables
 
    public standingState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
        myRigidBody = selfObject.GetComponent<Rigidbody2D>();
        playerScript = selfObject.GetComponent<playerScript>();
        playerScript.attack.performed += context => performAttack(context);
    }

    public override void EnterState()
    {
        Debug.Log("yep, it works!");
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

    public void movement(float speed, Vector2 direction) 
    {
        Debug.Log(direction);
        myRigidBody.velocity = direction * speed;
    }

    public void performAttack(InputAction.CallbackContext context)
    {

    }
}

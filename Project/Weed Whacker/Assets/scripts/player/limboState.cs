using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class limboState : BaseState<playerScript.States>
{
    private playerScript playersScript;
    public event EventHandler onJoinSmacked;

    public limboState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
        playersScript = selfObject.GetComponent<playerScript>();
        playersScript.joinGame.performed += context => joinGame(context);
    }

    public override void EnterState()
    {
        playersScript.controls.currentActionMap = playersScript.controls.
        //selfObject.GetComponent<Animator>().SetTrigger("backToDemoScreen");
    }

    public override void ExitState() //essentially the "on spawn" function... though when i work on rezzing stuff, might have to make this a function th acutally nmv
    {
        selfObject.GetComponent<Animator>().SetTrigger("gameJoin");
    }

    public override playerScript.States GetNextState()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        
    }
    public void joinGame(InputAction.CallbackContext context)
    {

    }
}

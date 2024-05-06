using NUnit.Framework.Constraints;
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
    public bool startUpScreenOver;

    public limboState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        StateIWantToBe = key;
        selfObject = SelfObject;
        playersScript = selfObject.GetComponent<playerScript>();
    }

    public override void EnterState()
    {
        playersScript.attack.performed += context => joinGame(context); //forget having action maps change :shrug: ill just have functions subscribe and unsubscribe...
        //selfObject.GetComponent<Animator>().SetTrigger("backToDemoScreen");
    }

    public override void ExitState() //essentially the "on spawn" function... though when i work on rezzing stuff, might have to make this a function th acutally nmv
    {
        playersScript.attack.performed -= context => joinGame(context);
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
        selfObject.GetComponent<Animator>().SetTrigger("gameJoin");
        StateIWantToBe = playerScript.States.standing;
    }
}

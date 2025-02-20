using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class limboState : BaseState<playerScript.States>
{
    private playerScript playersScript;
    public event EventHandler onJoinSmacked; // unity says this goes unused, but im keeping it just in case bc im afraid something will blow up if i remove it...
    public bool startUpScreenOver = false; //after the startup screen, this *should* always be true; videoPlayerScript sets it to true upon awakening, and nothing else should say otherwise

    public limboState(playerScript.States key, GameObject SelfObject) : base(key, SelfObject)
    {
        StateKey = key;
        Debug.Log("limbo state initialized!");
        StateIWantToBe = key;
        selfObject = SelfObject;
        playersScript = selfObject.GetComponent<playerScript>();
    }
   
    public override void EnterState()
    {
        playersScript.attack.performed += joinGameFromLimbo; //forget having action maps change :shrug: ill just have functions subscribe and unsubscribe...
        selfObject.GetComponent<Animator>().SetTrigger("backToDemoScreen");
        //Debug.Log("limboState EnterState() just ran");
    }

    public override void ExitState() //essentially the "on spawn" function... though when i work on rezzing stuff, might have to make this a function th acutally nmv
    {
        //Debug.Log("limboState ExitState() currently running...");
        playersScript.attack.performed -= joinGameFromLimbo;
        playersScript.notTheBallsTheManager = GameObject.Find("newGameManager");
        selfObject.GetComponent<Animator>().SetTrigger("gameJoin");
        GameObject.Find("newGameManager").GetComponent<GamerManager>().currentPlayers.Add(selfObject);
        if (selfObject.name == "player 1")
        {
            GameObject.Find("newGameManager").GetComponent<GamerManager>().player1 = selfObject;
        }
        else
        {
            GameObject.Find("newGameManager").GetComponent<GamerManager>().player2 = selfObject;
        }
        Debug.Log("limboState ExitState() just ran");
    }

    public override playerScript.States GetNextState()
    {
        return StateIWantToBe;
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


    public void joinGameFromLimbo(InputAction.CallbackContext context)
    {
        Debug.Log("joinGameFromLimbo() attempted... startupScreenOver is currently: " + playersScript.startUpScreenOver);
        if (playersScript.startUpScreenOver)
        {
            selfObject.GetComponent<Animator>().SetTrigger("gameJoin");
            //Debug.Log("animator trigger sent!");
            playersScript.StartCoroutine(playersScript.joinGameDelay()); //this makes it so that the player object can get a reference to the game manager without me having to actgually learn abt load priority :P
        }
    }

}

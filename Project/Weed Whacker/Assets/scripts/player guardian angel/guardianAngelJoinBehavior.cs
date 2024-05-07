using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class guardianAngelJoinBehavior : MonoBehaviour
{
    //public delegate void joinSmackedDelegate(/* maybe add parameters detailing like "hey im player 1 or 2" ... not sure how practical that'd be, but oh well :shrug:*/);
    //public event joinSmackedDelegate joinSmackedEvent;
    //public UnityEvent joinButtonSmacked;
    public int flagVar = 1;

    //public event EventHandler onJoinSmacked;

    //this script will rely on playerGuardianAngel.cs 's references instead of making its own, in an effort to cut down on memory usage. 
    public void Start()
    {
        if (this.gameObject.GetComponent<playerGuardianAngelScript>().playerControlssss == null)
        {
            print("uhoh the input action map reference didnt carry overrrrr oopsieeeees");
        }
        if (this.gameObject.GetComponent<playerGuardianAngelScript>().playerControlssss != null)
        {
            print("this was added properly, AND the input action map DID carry over... so whats the big deal??");
        }
    }
    public void spawnPlayer(InputAction.CallbackContext context)
    {
        print("join action smacked!");
        //onJoinSmacked?.Invoke(this, EventArgs.Empty);
        PlayerInput spawnedPlayer = PlayerInput.Instantiate(this.gameObject.GetComponent<playerGuardianAngelScript>().playerPrefab, controlScheme: "Debug"/*, pairWithDevice: Gamepad*/);
        //var playerSpawn = Instantiate(this.gameObject.GetComponent<playerGuardianAngelScript>().playerPrefab, InputControlScheme: "Debug");
        spawnedPlayer.GetComponent<playerScript>().controls = this.gameObject.GetComponent<playerGuardianAngelScript>().playerControlssss;
        //spawnedPlayer.GetComponent<playerScript>().okayNOWYouCanStart();
        this.gameObject.GetComponent<playerGuardianAngelScript>().deactivateJoinListener();
    }

    public void testType()
    {
        print("okay, so videoPlayerScript.cs CAN access functions, its just the parameter that's the issue here...");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class playerScript : StateMachine<playerScript.States>, Ientity, IWalkBehavior
{                                   //StateMachine already inherits from EntityClass, which inherits from MonoBehavior
    //controls
    public PlayerInput controls;
    [HideInInspector] public InputAction move;
    [HideInInspector] public InputAction attack;

    //references
    public Rigidbody2D myRigidBody2D;
    public SpriteRenderer spriteRenderer;
    public GameObject meObject;
    public GameObject myHitbox;
    public GameObject myHurtbox;
    public Animator myAnimator;
    [HideInInspector] public GameObject notTheBallsTheManager;
    public GameObject myUI;

    //handling
    public float moveSpeed;
    public float knockedMoveSpeed;
    public float rezCountLength;
    public int maxLives;
    public int myLayer;

    //internal handling
    [HideInInspector]  public bool startUpScreenOver = false;

    //public int crntHp;
    public int crntLives;

    //states
    public enum States
    {
        limbo,
        standing,
        knocked,
        dead
    }

    public Dictionary<States, BaseState<States>> StateDict = new Dictionary<States, BaseState<States>>();
    public BaseState<States> CrntState;

    //The meat of the code!
    void Start()
    {
        //dont destroy on load
        DontDestroyOnLoad(this.gameObject); //this is part of the guardian angel replacement; when going back to the demo screen, rather than anything else, just change the state to limbo; it will act as if this doesnt exist at all :shrug:

        //controls initialization
        move = controls.actions["move"];
        attack = controls.actions["attack"];

        //state machine intialization
        StateDict.Add(States.limbo, new limboState(States.limbo, meObject));
        StateDict.Add(States.standing, new standingState(States.standing, meObject));
        StateDict.Add(States.knocked, new knockedState(States.knocked, meObject));
        StateDict.Add(States.dead, new deadState(States.dead, meObject));
        CrntState = StateDict.GetValueOrDefault(States.limbo); //this is the startup screen stuff, replaces the guardian angel solution entirely
        CrntState.EnterState();

        //setting health; i so badly wanna just have this be in the entityClass script but it doesnt work :sob: so i gotta do it this way.... i gotta copy paste this in all entity scripts too...
        crntHp = maxHp;
        crntLives = maxLives;
        
        //entity class event subscription
        onHit += iJustGotSmackedFUCK;
        onDeath += onHealthEqualsZero;

        //controllercontroller shit
        GameObject controllerController = GameObject.Find("playerControllerController");
        print("controller controller's name is " + controllerController.name);
        transform.position = controllerController.GetComponent<setupScreenScript>().playerJoined();//tells teh setupScreen scirpt that a player has joined
        if (transform.position.x < 0)
        {
            this.gameObject.name = "player 1";
            controllerController.GetComponent<setupScreenScript>().nowForPlayer2();
        }
        else //a kind of roundabout way of saonsdf;zc
        {
            this.gameObject.name = "player 2";
            controllerController.GetComponent<setupScreenScript>().bothPlayersIn();
        }
    }

    public void printButtonHit(InputAction.CallbackContext context)
    {
        print("attack button hit!");
    }

    void Update()
    {
        States nextStateKey = CrntState.GetNextState();

        if (!isTransitioningState)//!isTransitioningState
        {
            if (!nextStateKey.Equals(CrntState.StateKey))  // a check like this running every frame seems unoptimal... im just copying off the video for now but i should come back and see if it cant be optimized  TO-DO-FLAG-1
            {
                print("CrntState and nextStateKey mismatch! transitioning!");
                stateTransition(nextStateKey);
            }
        }
        CrntState.UpdateState();
    }

    public void stateTransition(States stateKey)
    {
        isTransitioningState = true;
        print("about to run CrntState's ExitState()");
        CrntState.ExitState();
        print("just ran previous state's ExitState()");
        CrntState = StateDict[stateKey];
        print("current state changed! about to run current state's EnterState()...");
        CrntState.EnterState();
        print("current state's EnterState() just ran!");
        isTransitioningState = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        CrntState.OnTriggerEnter(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        CrntState.OnTriggerExit(collision);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        CrntState.OnTriggerStay(collision);
    }

    [ContextMenu("revive!")]
    public void revitalize() //for use with getting knocked
    {
        crntHp = maxHp;
        crntLives--;
        CrntState.StateIWantToBe = States.standing;
    }

    public void rezFinished()
    {
        revitalize();
    }

    public void backToDemoScreen()
    {
        CrntState.StateIWantToBe = States.limbo;
    }

    public void onHealthEqualsZero(object sender, EventArgs e)
    {
        print("------");
        print("onHealthEqualsZero() just ran!");
        print("------");
        if (notTheBallsTheManager.GetComponent<GamerManager>().amIAlone()) //if player is the only one in the scene....
        {
            print("i was just told i am alone...");
            CrntState.StateIWantToBe = States.dead;
            //notTheBallsTheManager.GetComponent<GamerManager>().wellGameEnd();
        }
        else
        {
            if (crntLives == 0)
            {
                CrntState.StateIWantToBe = States.dead;
            }
            else
            {
                CrntState.StateIWantToBe = States.knocked;
            }
        }
    }

    public IEnumerator joinGameDelay() //this is here so that the player can get a reference to the game manager without me having to learn about load priority :P
    {
        yield return new WaitForSeconds(.1f);
        CrntState.StateIWantToBe = playerScript.States.standing;
    }

    [ContextMenu("Remove from alive pool")] //for debugging
    public void removeFromAlivePool()
    {
        notTheBallsTheManager.GetComponent<GamerManager>().removePlayerFromAlivePool(this.gameObject);
    }

    [ContextMenu("Add to alive pool")] //for debugging
    public void addToAlivePool()
    {
        notTheBallsTheManager.GetComponent<GamerManager>().addPlayerToAlivePool(this.gameObject);
    }

    private void iJustGotSmackedFUCK(object sender, EventArgs e)
    {
        myAnimator.SetTrigger("wasHit");
    }
    
    private void imDeadAhhHell(object sender, EventArgs e)
    {
        myAnimator.SetTrigger("wasKillded");
    }

    //the following should only be called by states' update function!
    public void movement(float speed, Vector2 direction)
    {
        myRigidBody2D.velocity = direction * speed;   // also later, if possible, change this entirely so player accelerates and decelerates rather than just starting and stopping TO-DO-FLAG-3 
        /*
        myRigidBody2D.AddForce(direction * speed);
        print(direction * speed);
        */
        if (direction != Vector2.zero)             // WHOOOOOOO BOY this needs to be HELLA optimized, aint no way having this set every frame is healthy :skull:
        {
            //myAnimator.SetBool("isMoving", true);
        }
        else
        {
            //myAnimator.SetBool("isMoving", false);
        }
        //sprite flipping
        if (direction.x != 0)  //if player is currently inputting a move direction
        {
            if (direction.x < 0)
            {
                meObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                meObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}

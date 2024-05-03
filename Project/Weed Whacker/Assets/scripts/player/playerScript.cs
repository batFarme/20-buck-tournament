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
    [HideInInspector] public InputAction joinGame;

    //references
    public Rigidbody2D myRigidBody2D;
    public SpriteRenderer spriteRenderer;
    public GameObject meObject;
    public GameObject myHitbox;
    public GameObject myHurtbox;
    public Animator myAnimator;

    //handling
    public int maxHp;
    public float moveSpeed;
    /*
    public float accelSpeed;
    public float maxSpeed;
    */
    public int maxLives;
    public float knockedMoveSpeed;
    public float rezCountLength;
    public int myLayer;

    //internal handling
    public int crntHp;
    public int crntLives;

    //states
    public enum States
    {
        limbo,
        standing,
        knocked,
        dead
    }

    Dictionary<States, BaseState<States>> StateDict = new Dictionary<States, BaseState<States>>();
    public BaseState<States> CrntState;

    //The meat of the code!
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); //this is part of the guardian angel replacement; when going back to the demo screen, rather than anything else, just change the state to limbo; it will act as if this doesnt exist at all :shrug:
    }

    public void okayNOWYouCanStart() //i imagine monobehavior already has a solution for this but i am SO not going through a 500 page toyota corolla manual to do literally this for like a 70th of a frame's worth of performance
    {
        move = controls.actions["move"];
        attack = controls.actions["attack"];
        joinGame = controls.actions["join game"];
        StateDict.Add(States.limbo, new limboState(States.limbo, meObject));
        StateDict.Add(States.standing, new standingState(States.standing, meObject));
        StateDict.Add(States.knocked, new knockedState(States.knocked, meObject));
        StateDict.Add(States.dead, new deadState(States.dead, meObject));
        CrntState = StateDict.GetValueOrDefault(States.limbo); //this is the startup screen stuff, replaces the guardian angel solution entirely
        CrntState.EnterState();

    }
    void Update()
    {

        States nextStateKey = CrntState.GetNextState();

        if (!isTransitioningState)
        {
            if (!nextStateKey.Equals(CrntState.StateKey))  // a check like this running every frame seems unoptimal... im just copying off the video for now but i should come back and see if it cant be optimized  TO-DO-FLAG-1
            {
                stateTransition(nextStateKey);
            }
            CrntState.UpdateState();
        }
    }

    public void stateTransition(States stateKey)
    {
        isTransitioningState = true;
        CrntState.ExitState();
        CrntState = StateDict[stateKey];
        CrntState.EnterState();
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
    void playAnimation(Animation animationToPlay)
    {

    }

    public void revitalize(States fromWhatState)
    {
        crntHp = maxHp;
        if (fromWhatState == States.limbo)
        {
            crntLives = maxLives;
        }


    }
    public void takeHit() //becuase of the limitations of unity's event system, this can only take one parameter; if a reference to the attacking gameObject is needed, instead ask hurtbox
    {
        print("aw fuck someone hit me!!!!");
        crntHp--; //since theres no variation in damage
        if (crntHp <= 0)
        {
            if (crntLives == 0) //eithe knocked or die
            {
                //die
            }
            else 
            {
                crntLives--;
                //get knocked
            }
        }
        else
        {
            myAnimator.SetTrigger("wasHit");
            //also do some stuff for getting hit but also... maybe just do that shit in the animator? food for thought TO-DO-FLAG-5
        }
    }

    public void setMyLayer()
    {
        myHurtbox.GetComponent<hurtbox>().myLayer = myLayer;
    }

    public void movement(float speed, Vector2 direction)
    {
        myRigidBody2D.velocity = direction * speed;   // also later, if possible, change this entirely so player accelerates and decelerates rather than just starting and stopping TO-DO-FLAG-3 
        /*
        myRigidBody2D.AddForce(direction * speed);
        print(direction * speed);
        */
        if (direction != Vector2.zero)             // WHOOOOOOO BOY this needs to be HELLA optimized, aint no way having this set every frame is healthy :skull:
        {
            myAnimator.SetBool("isMoving", true);
        }
        else
        {
            myAnimator.SetBool("isMoving", false);
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
        {

        }
        /*
        if (myRigidBody.velocity != Vector2.zero)
        {

        }
        selfObject.transform.localScale = new Vector3(1, selfObject.transform.localScale.y, selfObject.transform.localScale.z);
        */
    }
}

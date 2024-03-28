using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : StateMachine<playerScript.States>, Ientity
{                                   //StateMachine already inherits from MonoBehaviour
    //controls
    public PlayerInput controls;
    public InputAction move;
    public InputAction attack;

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
    public float knockedMoveSpeed;
    public float rezCountLength;

    //internal handling
    private int crntHp;

    //states
    public enum States
    {
        standing,
        knocked,
        dead
    }

    Dictionary<States, BaseState<States>> StateDict = new Dictionary<States, BaseState<States>>();
    BaseState<States> CrntState;

    //The meat of the code!
    void Start()
    {
        crntHp = maxHp;
        move = controls.actions["move"];
        attack = controls.actions["attack"];
        StateDict.Add(States.standing, new standingState(States.standing, meObject));
        StateDict.Add(States.knocked, new knockedState(States.knocked, meObject));
        StateDict.Add(States.dead, new deadState(States.dead, meObject));
        CrntState = StateDict.GetValueOrDefault(States.standing);
        CrntState.EnterState();
    }

    void Update()
    {

        States nextStateKey = CrntState.GetNextState();

        if (!isTransitioningState)
        {
            if (!nextStateKey.Equals(CrntState.StateKey))  // a check like this running every frame seems unoptimal... im just copying off the video for now but i should come back and see if it cant be optimized  TO-DO-FLAG-1
            {
                TransitionToState(nextStateKey);
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

    public void takeHit(int dmgTaken)
    {
        crntHp -= dmgTaken;
        myAnimator.SetTrigger("wasHit");
    }
}

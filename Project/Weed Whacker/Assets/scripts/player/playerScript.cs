using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : StateMachine<playerScript.States>
{                                   //StateMachine already inherits from MonoBehaviour
    //references
    public InputAction controlMovement;
    public InputAction attackButton;
    public Rigidbody2D myRigidBody2D;
    public GameObject meObject;
    public GameObject myHitbox;
    public GameObject myHurtbox;
    public Animator myAnimator;

    //handling
    public float moveSpeed;
    public float rezCountLength;

    //internal control variables
    private Vector2 moveDirection;

    //States
    public enum States
    {
        standing,
        knocked,
        dead
    }

    Dictionary<States, BaseState<States>> StateDict = new Dictionary<States, BaseState<States>>();
    BaseState<States> CrntState;

    //The Meat!
    void Start()
    {
        StateDict.Add(States.standing, new standingState(States.standing, meObject));
        StateDict.Add(States.knocked, new knockedState(States.knocked, meObject));
        StateDict.Add(States.dead, new deadState(States.dead, meObject));
        CrntState = StateDict.GetValueOrDefault(States.standing);
        CrntState.EnterState();
    }

    private void OnEnable() // the guy in the video said to put these in, theyre for the input system apparently -- need to rework
    {                       // once i learn what im doing :skull: TO-DO-FLAG-2
        controlMovement.Enable();
        attackButton.Enable();
        //attackButton.performed += attack;
    }

    private void OnDisable()
    {
        controlMovement.Disable();
        attackButton.Disable();
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
}

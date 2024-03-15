using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : StateMachine<playerScript.States> //StateMachine already inherits from MonoBehaviour
{
    //references
    public InputAction controlMovement;
    public InputAction attackButton;
    public Rigidbody2D myRigidBody2D;
    public GameObject myHitbox;
    public GameObject myHurtbox;
    public GameObject shovelSprite;
    public Animator myAnimator;

    //handling
    public float moveSpeed;

    //internal control variables
    private delegate void crntStateExecute();
    crntStateExecute crntState;
    private Vector2 moveDirection;

    //States

    public enum States
    {
        standing,
        knocked,
        dead
    }

    void Start()
    {
        //crntState = standingState;
    }

    private void OnEnable()
    {
        controlMovement.Enable();
        attackButton.Enable();
        //attackButton.performed += attack;
    }

    private void OnDisable()             // the guy in the video said to put these in... whatever they do
    {
        controlMovement.Disable();
        attackButton.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        crntState();
    }
    
}

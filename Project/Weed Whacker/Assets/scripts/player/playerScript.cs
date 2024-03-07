using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
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

    //states
    // BAM easy fix to the problem i had where i didnt knwo what variable type funcitons would b considered
    public class State
    {
        //public void 
    }

    // Start is called before the first frame update
    void Start()
    {
        crntState = standingState;
    }

    private void OnEnable()
    {
        controlMovement.Enable();
        attackButton.Enable();
        attackButton.performed += attack;
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
    
    private string stateTransition(string stateName)
        //rather than simply setting the crntState var in code directly, use this (future-proofing)
        //also WAAAHHH IDK WHAT VARIABLE TYPE FUNCTIONS AREEEEEE this is so effed up man
    {

    }
    // states; when set as crntState, they are called every frame
    private void standingState() //stateName is standingState
    {
        moveDirection = controlMovement.ReadValue<Vector2>();
        myRigidBody2D.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); //movement
    }

    private void knockedState() //stateName is knockedState
    {

    }

    private void deadState() //stateName is deadState
    {

    }
    private void attack(InputAction.CallbackContext context)
    {

    }
}

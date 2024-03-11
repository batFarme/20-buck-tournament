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
    private State crntState;
    private Vector2 moveDirection;

    //states
    // BAM easy fix to the problem i had where i didnt knwo what variable type funcitons would b considered
    public class State
    {
        public void onFirst()
        {

        }
        public void run()
        {

        }
    }

    private State idle = new State();
    
    // Start is called before the first frame update
    void Start()
    {
        crntState.run();
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
        crntState.run();
    }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

    private void setState()
=======
=======
>>>>>>> bbd77873f7d9bd0deda850e388e927fca364707c
=======
>>>>>>> bbd77873f7d9bd0deda850e388e927fca364707c
    
    private string stateTransition(string stateName)
        //rather than simply setting the crntState var in code directly, use this (future-proofing)
        //also WAAAHHH IDK WHAT VARIABLE TYPE FUNCTIONS AREEEEEE this is so effed up man
>>>>>>> bbd77873f7d9bd0deda850e388e927fca364707c
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    //references
    public InputAction playerControls;
    public Rigidbody2D myRigidBody2D;

    //handling
    public float moveSpeed;

    //internal control variables
    private delegate void crntStateExecute();
    crntStateExecute crntState;

    // Start is called before the first frame update
    void Start()
    {
        crntState = standingState;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()             // the guy in the video said to put these in... whatever they do
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        crntState();
    }

    private void stateTransition()  //rather than simply setting the crntState var in code directly, use this (future-proofing)
    {

    }
    // states; when set as crntState, they are called every frame
    private void standingState()
    {
        myRigidBody2D.velocity = new Vector2(playerControls.ReadValue<Vector2>().x * moveSpeed, playerControls.ReadValue<Vector2>().y * moveSpeed);
    }

    private void knockedState()
    {

    }
}

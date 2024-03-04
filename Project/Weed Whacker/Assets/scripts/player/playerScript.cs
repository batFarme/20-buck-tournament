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
    private class crntState;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody2D.velocity = new Vector2(playerControls.ReadValue<Vector2>().x * moveSpeed, playerControls.ReadValue<Vector2>().y * moveSpeed);
    }

    private void stateTransition()
    {

    }
}

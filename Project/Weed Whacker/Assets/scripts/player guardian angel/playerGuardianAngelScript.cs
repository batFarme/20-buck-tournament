using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerGuardianAngelScript : MonoBehaviour
{

    public PlayerInput playerControlssss;
    [HideInInspector] public InputAction joinAction;
    [HideInInspector] public Vector2 spawnPos;
    public GameObject playerPrefab;
    public int playerNumber = 0;

    // Update is called once per frame
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        GameObject controllerController = GameObject.Find("playerControllerController");
        print("controller controller's name is " + controllerController.name);
        transform.position = controllerController.GetComponent<setupScreenScript>().playerJoined();//tells teh setupScreen scirpt that a player has joined
        if (transform.position.x < 0)
        {
            this.gameObject.name = "player 1 guardian angel";
            playerNumber = 1;
            controllerController.GetComponent<setupScreenScript>().nowForPlayer2();
        }
        else //a kind of roundabout way of saonsdf;zc
        {
            this.gameObject.name = "player 2 guardian angel";
            playerNumber = 2;
            controllerController.GetComponent<setupScreenScript>().bothPlayersIn();
        }

        joinAction = playerControlssss.actions["join game"];
    }

    void activateJoinListener()
    {
        this.gameObject.AddComponent<guardianAngelJoinBehavior>();
        joinAction.performed += context => this.gameObject.GetComponent<guardianAngelJoinBehavior>().spawnPlayer(context);
    }

    public void deactivateJoinListener()
    {
        Destroy(this.gameObject.GetComponent<guardianAngelJoinBehavior>());
    }
}

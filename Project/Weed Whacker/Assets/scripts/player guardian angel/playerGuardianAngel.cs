using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerGuardianAngel : MonoBehaviour
{

    public PlayerInput playerControlssss;
    [HideInInspector] public Vector2 spawnPos;
    public GameObject playerPrefab;
    // Update is called once per frame
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        GameObject controllerController = GameObject.Find("playerControllerController");
        transform.position = controllerController.GetComponent<setupScreenScript>().playerJoined();//tells teh setupScreen scirpt that a player has joined
        if (transform.position.x < 0)
        {
            this.gameObject.name = "player 1 guardian angel";
            controllerController.GetComponent<setupScreenScript>().nowForPlayer2();
        }
        else //a kind of roundabout way of saonsdf;zc
        {
            this.gameObject.name = "player 2 guardian angel";
            controllerController.GetComponent<setupScreenScript>().bothPlayersIn();
        }
        
    }

    void activateJoinListener()
    {
        this.gameObject.AddComponent<guardianAngelJoinBehavior>();
    }

}

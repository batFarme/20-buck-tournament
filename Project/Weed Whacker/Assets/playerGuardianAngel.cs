using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGuardianAngel : MonoBehaviour
{
    public Vector2 spawnPos;
    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        GameObject controllerController = GameObject.Find("playerControllerController");
        transform.position = controllerController.GetComponent<setupScreenScript>().playerJoined();//tells teh setupScreen scirpt that a player has joined
        if (transform.position.x > 0) //a kind of roundabout way of saonsdf;zc
        {
            controllerController.GetComponent<setupScreenScript>().bothPlayersIn();
        }
    }
}

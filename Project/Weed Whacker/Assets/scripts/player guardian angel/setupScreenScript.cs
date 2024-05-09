using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class setupScreenScript : MonoBehaviour
{
    public TextMeshProUGUI controllerPrompt;
    public int amtPlayersJoined = 0;
  
    public Vector2 player1SpawnPos = new Vector2(-1.73f, -1.14f);
    public Vector2 player2SpawnPos = new Vector2(1.73f, -1.14f); 
    public Vector2 defualtSpawnPos = new Vector2(0, 0);

    public GameObject eventSystemObject;

    private void Awake()
    {
        /*
        EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventSystem.enabled = false;
        */
        //InputSystem.DisableDevice(Mouse.current); //because for some unGODLY reason, unity is so fucking hell bent on reading the mouse input EVEN WHEN THERES LITERALLY NO CODE (written by me) TELLING IT TO READ MOUSE INPUT. GRR.
        //DontDestroyOnLoad(eventSystemObject); //THIS BETTER FREAKING WORK UGGHHHH. I HATE UNITY SO FUCKING MUCH.
    }

    public Vector2 playerJoined()
    {
        amtPlayersJoined++;
        print("player joined! amt of players is now " + amtPlayersJoined);
        switch (amtPlayersJoined)
        {
            case 1: print("player 1 joined"); return player1SpawnPos; //the loaded prefabs themselves will call the nowForPlayer2() and bothPlayersIn() funcitons
            case 2: print("player 2 joined"); return player2SpawnPos; //need to fix this order
            default: print("somethings bwokey 3:");  return defualtSpawnPos;
        }
    }
    public void nowForPlayer2()
    {
        controllerPrompt.text = "Hit the button for player 2 (right side)";
    }
    public void bothPlayersIn()
    {
        SceneManager.LoadScene("demoScreen");
        //load the demoscreen
    }
}


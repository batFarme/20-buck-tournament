using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class setupScreenScript : MonoBehaviour
{
    public TextMeshProUGUI waitingText;
    public int amtPlayersJoined;

    public Vector2 player1SpawnPos = new Vector2(-1.73f, -1.14f);
    public Vector2 player2SpawnPos = new Vector2(1.73f, -1.14f); 


    public Vector2 playerJoined()
    {
        amtPlayersJoined++;
        switch (amtPlayersJoined)
        {
            case 1: print("player 1 joined"); nowForPlayer2(); return player1SpawnPos;
            case 2: print("player 2 joined"); return player2SpawnPos; //need to fix this order
        }
    }
    public void nowForPlayer2()
    {

    }
    public void bothPlayersIn()
    {
        //load the demoscreen
    }
}


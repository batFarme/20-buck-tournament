using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // i actually dont know what this does....
    public GameObject player1;
    public GameObject player2;
    public List<GameObject> spawnerList = new List<GameObject>();
    public GameObject weedPrefab;
    List<GameObject> bothPlayers = new List<GameObject>();   //ohhhh this is so scuffed but whatever
    List<GameObject> alivePlayers = new List<GameObject>();   // AAAHHHHHH this looks like TF2's code but WHATEVER I DONT CARE RAAHHHHHHH
    //List<bool> playerAliveStatus = new List<bool>();
    List<GameObject> allFlowers = new List<GameObject>();
    public GameObject theWell;  //this should be set in the editor

    public float weedSpeed; // lol

    private GameObject weedCreate;

    public enum GameState
    {
        waveActive,
        waveCelebrate,
        waveBeginning,
        gameLost
    }

    private void Awake()
    {
        Instance = this;
        bothPlayers.Add(player1);
        //bothPlayers.Add(player2);      just for now, until i figure out how to get two controllers

        /*  commenting this block out because bothPlayers isnt bieng used rn but if i need to go back to it, i wont have to rewrite all this
        for (int i = 0; i < bothPlayers.Count; i++) //this method works for however many players are in a game; works as future proofing, but im just writing it like this bc id rather write this now than have to rewrite this when i get a second player in the game
        {
            playerAliveStatus.Add(true);
        }
        */
        alivePlayers = bothPlayers;  //grinning like  a dumbass at this :3
    }

    
    void spawnWeed(GameObject targetToGive) //the core weed spawning function.
    {
        weedCreate = Instantiate(weedPrefab);
        weedCreate.transform.position = spawnerList[Random.Range(0, spawnerList.Count)].transform.position;
        print(weedCreate.transform.position);
        weedScript weedCreatesScript = weedCreate.GetComponent<weedScript>();
        weedCreatesScript.originalTarget = targetToGive;
        weedCreatesScript.linkCheck();
        weedCreatesScript.moveSpeed = weedSpeed;
        print("weed born at " + weedCreate.transform.position + "; newborn weed wants to target " + weedCreatesScript.originalTarget.name);
    }

    //the following weed spawning functions are here for debugging purposes.
    [ContextMenu("spawnWeedRandTarget")] 
    void spawnWeedRandTarget()
    {
        spawnWeed(randomTarget());
    }

    [ContextMenu("spawnWeedPlayer1")]
    void spawnWeedPlayer1()
    {
        spawnWeed(player1);
    }

    [ContextMenu("spawnWeedPlayer2")]
    void spawnWeedPlayer2()
    {
        spawnWeed(player2);
    }

    [ContextMenu("spawnWeedWell")]
    void spawnWeedWell()
    {
        spawnWeed(theWell);
    }

    [ContextMenu("spawnWeedFlower")]
    void spawnWeedFlower()
    {
        spawnWeed(randomFlower());
    }



    public GameObject randomTarget()
    {
        int randomTarget;
        GameObject targetToReturn;

        if (allFlowers.Count != 0) //if no flowers are on the field, just pick between either the well or players
        {
            randomTarget = Random.Range(1, 2);
        }
        else
        {
            randomTarget = Random.Range(1, 3);
        }

        switch (randomTarget)
        {
            case 1: targetToReturn = theWell; break;
            case 2: targetToReturn = alivePlayers[Random.Range(0,alivePlayers.Count)]; break; 
            case 3: targetToReturn = randomFlower(); break;
            default: Debug.Log("what the fuck"); targetToReturn = null; break;
        }

        return targetToReturn;
    }

    GameObject randomFlower()
    {
        return allFlowers[Random.Range(0, allFlowers.Count)];
    }
}

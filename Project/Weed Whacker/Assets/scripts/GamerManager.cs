using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GamerManager : MonoBehaviour //its named GamerManager rather than the usual GameManager cause gamemanager persists between scenes and i did NOT code with that in mind so i am just changing it so i have less work to do :P
{
    public static GamerManager Instance;  // i actually dont know what this does....
    public GameObject player1;
    public GameObject player2;
    public List<GameObject> currentPlayers = new List<GameObject>();   //ohhhh this is so scuffed but whatever
    public List<GameObject> alivePlayers = new List<GameObject>();   // AAAHHHHHH this looks like TF2's code but WHATEVER I DONT CARE RAAHHHHHHH
    public List<GameObject> spawnerList = new List<GameObject>();
    public GameObject weedPrefab;
    public GameObject flowerPrefab;
    //List<bool> playerAliveStatus = new List<bool>();
    List<GameObject> allFlowers = new List<GameObject>();
    public GameObject theWell;  //this should be set in the editor
    public float weedSpeed; // lol

    public enum GameState //this is currently unused, and im pretty sure itll stay unused since its not actually needed...
    {
        waveActive,
        waveCelebrate,
        waveBeginning,
        gameLost
    }

    private void Awake()
    {
        Instance = this;

        alivePlayers = currentPlayers;  //grinning like  a dumbass at this :3
    }

    void spawnFlower(GameObject theWell)
    {
        var flowerCreate = Instantiate(flowerPrefab);
        flowerPrefab.transform.position = spawnerList[Random.Range(0, spawnerList.Count)].transform.position;
        flowerScript flowerCreatesScript = flowerCreate.GetComponent<flowerScript>();
        flowerCreatesScript.theWell = theWell;
        allFlowers.Add(flowerCreate);
    }

    void spawnWeed(GameObject targetToGive) //the core weed spawning function.
    {
        var weedCreate = Instantiate(weedPrefab);
        weedCreate.transform.position = spawnerList[Random.Range(0, spawnerList.Count)].transform.position;
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

    public void addPlayerToAlivePool(GameObject thePlayerInQuestion)
    {
        alivePlayers.Add(thePlayerInQuestion);
    }

    public void removePlayerFromAlivePool(GameObject thePlayerInQuestion)
    {
        alivePlayers.Remove(thePlayerInQuestion);
    }

    GameObject randomFlower()
    {
        return allFlowers[Random.Range(0, allFlowers.Count)];
    }
}

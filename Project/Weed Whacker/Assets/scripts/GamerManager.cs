using JetBrains.Annotations;
using System;
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
    public List<GameObject> allFlowers = new List<GameObject>();
    public GameObject theWell;  //this should be set in the editor
    public float weedSpeed; // lol

    public int crntWave = 0;
    private int amtOfEnemiesToSpawn = 0;

    private List<GameObject> aliveEnemyPool = new List<GameObject>();

    private void Awake()
    {
        /*
        if (GameObject.Find("EventSystem"))
        EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventSystem.enabled = false;
        */
        Instance = this;

        crntWave = 0;
        amtOfEnemiesToSpawn += 2;
        alivePlayers = currentPlayers;  //grinning like  a dumbass at this :3

    }

    private void Start()
    {
        StartCoroutine(firstWaveStart());
    }

    public IEnumerator firstWaveStart()
    {
        yield return new WaitForSeconds(.1f);
        newWave();
    }

    void spawnFlower(GameObject theWell)
    {
        var flowerCreate = Instantiate(flowerPrefab);
        flowerPrefab.transform.position = spawnerList[UnityEngine.Random.Range(0, spawnerList.Count - 1)].transform.position;
        flowerScript flowerCreatesScript = flowerCreate.GetComponent<flowerScript>();
        flowerCreatesScript.theWell = theWell;
        allFlowers.Add(flowerCreate);
    }

    void spawnWeed(GameObject targetToGive) //the core weed spawning function; NOT TO BE CALLED ON ITS OWN!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        var weedCreate = Instantiate(weedPrefab);
        weedCreate.transform.position = spawnerList[UnityEngine.Random.Range(0, spawnerList.Count - 1)].transform.position;
        weedScript weedCreatesScript = weedCreate.GetComponent<weedScript>();
        weedCreatesScript.originalTarget = targetToGive;
        weedCreatesScript.linkCheck();
        weedCreatesScript.moveSpeed = weedSpeed;
        aliveEnemyPool.Add(weedCreate);
        weedCreate.GetComponent<weedScript>().notTheBallsTheManager = gameObject;
        //print("weed born at " + weedCreate.transform.position + "; newborn weed wants to target " + weedCreatesScript.originalTarget.name);
    }

    public void removeWeedFromPool(GameObject theWeedInQuestion)
    {
        aliveEnemyPool.Remove(theWeedInQuestion);
        if (aliveEnemyPool.Count == 0)
        {
            newWave();
        }
    }

    void newWave()
    {
        crntWave++;
        amtOfEnemiesToSpawn++;
        startWave(); //later, after new wave animation is finsihed, have start wave be called at the end of that animation rather than being called immeidately in code, to make the situation more clear.
    }

    void startWave()
    {
        for (int i = amtOfEnemiesToSpawn; i > 0; i--)
        {
            spawnWeedRandTarget();// maybe make the spawns staggered, say within a 10 second window?
        }
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

    public void deathCheck()
    {
        //check player count, if theres only one and that one has just been knocked, just make em dead and show a game over screen. 
    }

    public GameObject randomTarget()
    {
        int randomTarget;
        GameObject targetToReturn;

        if (allFlowers.Count != 0) //if no flowers are on the field, just pick between either the well or players
        {
            randomTarget = UnityEngine.Random.Range(1, 2);
        }
        else
        {
            randomTarget = UnityEngine.Random.Range(1, 3);
        }

        switch (randomTarget)
        {
            case 1: targetToReturn = theWell; break;
            case 2: targetToReturn = randomPlayer(); break; 
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

    GameObject randomPlayer()
    {
        int e;
        
        if (alivePlayers.Count > 1)
        {
            print("there are two players");
            e = UnityEngine.Random.Range(1, alivePlayers.Count);
        }
        else
        {
            print("there is only one player");
            e = 0;
        }
        print(alivePlayers + ": these are the alive players");
        print("rng picks " + e + " to feed.");
        print("feeding the weed this player: " + alivePlayers[e]);
        return alivePlayers[e];
    }

    GameObject randomFlower()
    {
        int e;
        /*
        if (allFlowers.Count > 1)
        {
            e = UnityEngine.Random.Range(0, allFlowers.Count - 1);
        }
        else
        {
            e = 0;
        }
        */
        e = UnityEngine.Random.Range(1, allFlowers.Count);
        print("feeding the weed this flower: " + allFlowers[e]);
        return allFlowers[e];
    }

    public IEnumerator spawnFlowerCoroutine()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 5f));
        spawnFlower(theWell);
    }
}

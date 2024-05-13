using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GamerManager : MonoBehaviour //its named GamerManager rather than the usual GameManager cause gamemanager persists between scenes and i did NOT code with that in mind so i am just changing it so i have less work to do :P
{
    public Animator myAnimator;

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
    public AudioSource myJukebox;
    public List<AudioClip> songList = new List<AudioClip>();
    public int crntWave = 0;
    private int amtOfEnemiesToSpawn = 0;

    private List<GameObject> aliveEnemyPool = new List<GameObject>();

    private bool isGameCurrentlyEnding = false;

    public event EventHandler allPlayersDeadEvent;

    private void Awake()
    {
        Instance = this;

        crntWave = 0;
        amtOfEnemiesToSpawn += 2;
    }
    private void Start()
    {
        
        theWell.GetComponent<wellScript>().onDeath += wellGameEnd;
        allPlayersDeadEvent += wellGameEnd;
        StartCoroutine(firstWaveStart());
        AudioResource songToPlay = songList[UnityEngine.Random.Range(0, songList.Count)];
        myJukebox.resource = songToPlay;
        print("now playing: " + songToPlay.name);
    }

    public IEnumerator firstWaveStart()
    {
        yield return new WaitForSeconds(.1f);
        StartCoroutine(flowerSpawnLoop());
        newWave();
    }

    public IEnumerator flowerSpawnLoop()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 5f));
        spawnFlower(theWell);
        StartCoroutine(flowerSpawnLoop());
    }

    public void wellGameEnd(object sender, EventArgs e) //this is a seperate function cause of event stuff
    {
        print("game manager recieved well game end signal!");
        isGameCurrentlyEnding = true;
        myAnimator.SetTrigger("onLose");
    }

    public void returnToDemoScreen()
    {
        print("going back to the demo scene!");
        if (player1.GetComponent<playerScript>().CrntState != player1.GetComponent<playerScript>().StateDict[playerScript.States.limbo]) //"if this player's state isnt currently limbo, then..."
        {
            print("player1 is present; setting their state to limbo");
            player1.GetComponent<playerScript>().backToDemoScreen();
        }
        if (player2.GetComponent<playerScript>().CrntState != player2.GetComponent<playerScript>().StateDict[playerScript.States.limbo]) //"if this player's state isnt currently limbo, then..."
        {
            print("player2 s present; setting their state to limbo");
            player2.GetComponent<playerScript>().backToDemoScreen();
        }
        SceneManager.LoadScene("demoScreen");
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
        Vector2 spawnerPosToUse = spawnerList[UnityEngine.Random.Range(0, spawnerList.Count - 1)].transform.position;
        weedCreate.transform.position = new Vector2(UnityEngine.Random.Range(spawnerPosToUse.x - .5f, spawnerPosToUse.x + .5f), UnityEngine.Random.Range(spawnerPosToUse.y - .5f, spawnerPosToUse.y + .5f)); //the random ranges here are to make it so that weeds dont like hide behind eachother, making 2 weeds look like just one
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


    public bool amIAlone()
    {
        if (alivePlayers.Count == 1)
        {
            print("yes, you are alone");
            return true;
        }
        else
        {
            return false;
        }
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
        print(alivePlayers.Count + " players are left standing....");
        if (alivePlayers.Count == 0)
        {
            print("all players are dead!");
            allPlayersDeadEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    GameObject randomPlayer()
    {
        int e;
        
        if (alivePlayers.Count == 2)
        {
            print("there are two players");
            e = UnityEngine.Random.Range(1, alivePlayers.Count);
        }
        else if (alivePlayers.Count == 1)
        {
            print("there is only one player");
            e = 0;
        }
        else
        {
            print("there are no players in the scene!");
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

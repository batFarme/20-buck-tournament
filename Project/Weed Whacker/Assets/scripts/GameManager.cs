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
    List<GameObject> allFlowers = new List<GameObject>();
    public GameObject theWell;  //this should be set in the editor

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
        bothPlayers.Add(player2);
    }

    void spawnWeed()
    {
        weedCreate = Instantiate(weedPrefab);
        weedCreate.transform.position = spawnerList[Random.Range(0, spawnerList.Count)].transform.position;
        weedCreate.GetComponent<weedScript>().originalTarget = randomTarget();
    }

    GameObject randomTarget()
    {
        int randomTarget = Random.Range(1, 3); //this feels. unoptimal. ugh.
        GameObject targetToReturn;

        switch (randomTarget)
        {
            case 1: targetToReturn = theWell; break;
            case 2: targetToReturn = bothPlayers[Random.Range(0,1)]; break;//hard coded for 2 players; i WOULD future proof but like the parts are already ordered, so... too late :shrug:
            case 3: targetToReturn = allFlowers[Random.Range(0,allFlowers.Count)]; break;
            default: Debug.Log("what the fuck"); targetToReturn = null; break;
        }
        return targetToReturn;
    }
}

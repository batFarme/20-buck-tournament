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
        //bothPlayers.Add(player2);      just for now, until i figure out how to get two controllers
    }

    [ContextMenu("spawnWeed")]
    void spawnWeed()
    {
        weedCreate = Instantiate(weedPrefab);
        weedCreate.transform.position = spawnerList[Random.Range(0, spawnerList.Count)].transform.position;
        print(weedCreate.transform.position);
        GameObject targetToGive;
        targetToGive = randomTarget();
        weedCreate.GetComponent<weedScript>().originalTarget = targetToGive;
        weedCreate.GetComponent<weedScript>().linkCheck();
        print("weed born at " + weedCreate.transform.position + "; newborn weed wants to target " + weedCreate.GetComponent<weedScript>().originalTarget.name);
    }

    GameObject randomTarget()
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
            case 2: targetToReturn = bothPlayers[Random.Range(0,bothPlayers.Count)]; break;
            case 3: targetToReturn = allFlowers[Random.Range(0,allFlowers.Count)]; break;
            default: Debug.Log("what the fuck"); targetToReturn = null; break;
        }

        return targetToReturn;
    }
}

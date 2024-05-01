using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class guardianAngelJoinBehavior : MonoBehaviour
{
    public Event joinButtonSmacked;
    public int flagVar = 1;
    //this script will rely on playerGuardianAngel.cs 's references instead of making its own, in an effort to cut down on memory usage. 
    public void spawnPlayer(InputAction.CallbackContext context)
    {
        print("join action smacked!");
        //joinButtonSmacked.Invoke();
        var playerSpawn = Instantiate(this.gameObject.GetComponent<playerGuardianAngelScript>().playerPrefab);
        playerSpawn.GetComponent<playerScript>().controls = this.gameObject.GetComponent<playerGuardianAngelScript>().playerControlssss;
        playerSpawn.GetComponent<playerScript>().okayNOWYouCanStart();
        this.gameObject.GetComponent<playerGuardianAngelScript>().deactivateJoinListener();
    }
}

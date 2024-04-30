using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class guardianAngelJoinBehavior : MonoBehaviour
{
    //this script will rely on playerGuardianAngel.cs 's references instead of making its own, in an effort to cut down on memory usage. 
    public void spawnPlayer()
    {
        var playerSpawn = Instantiate(this.gameObject.GetComponent<playerGuardianAngel>().playerPrefab);
        playerSpawn.GetComponent<playerScript>().controls = this.gameObject.GetComponent<playerGuardianAngel>().playerControlssss;
        playerSpawn.GetComponent<playerScript>().okayNOWYouCanStart();
    }
}

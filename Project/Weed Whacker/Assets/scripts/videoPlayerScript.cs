using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using System;
using static UnityEditor.Experimental.GraphView.GraphView;

public class videoPlayerScript : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    //public UnityAction itsShowtimeAction;
    public void Awake()
    {
        //itsShowtimeAction += itsShowtimeFunction; //honestly no clue why unityevents cant just have regular methods as listeners and needs so badly to have a unityaction in between, but what fucking ever
        print("it did the thing");

        player1 = GameObject.Find("player 1 guardian angel");
        player1.GetComponent<playerGuardianAngelScript>().activateJoinListener();
        player1.GetComponent<guardianAngelJoinBehavior>().onJoinSmacked += itsShowtime;
        /*
        player1.AddComponent<guardianAngelJoinBehavior>();
        */
        player2 = GameObject.Find("player 2 guardian angel");
        player2.GetComponent<playerGuardianAngelScript>().activateJoinListener();
        player2.GetComponent<guardianAngelJoinBehavior>().onJoinSmacked += itsShowtime;
        /*
        player2.AddComponent<guardianAngelJoinBehavior>();
        player2.GetComponent<guardianAngelJoinBehavior>().onJoinSmacked += itsShowtime;
        */
    }

    public void itsShowtime(object sender, EventArgs e)
    {
        print("its showtime!!!!");
        player1.GetComponent<guardianAngelJoinBehavior>().onJoinSmacked -= itsShowtime; //im actually not sure if unsubscribing is actually necessary, since this object is going to be destroyed after loading the scene... oh well!
        player2.GetComponent<guardianAngelJoinBehavior>().onJoinSmacked -= itsShowtime;
        SceneManager.LoadScene("debugScene");
    }
}

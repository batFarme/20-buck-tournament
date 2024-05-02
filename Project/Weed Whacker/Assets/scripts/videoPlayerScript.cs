using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using System;

public class videoPlayerScript : MonoBehaviour
{
//public UnityAction itsShowtimeAction;
    public void Awake()
    {
        //itsShowtimeAction += itsShowtimeFunction; //honestly no clue why unityevents cant just have regular methods as listeners and needs so badly to have a unityaction in between, but what fucking ever
        print("it did the thing");

        GameObject player1 = GameObject.Find("player 1 guardian angel");
        player1.AddComponent<guardianAngelJoinBehavior>();
        player1.GetComponent<guardianAngelJoinBehavior>().onJoinSmacked += itsShowtime;
        GameObject player2 = GameObject.Find("player 2 guardian angel");
        player2.AddComponent<guardianAngelJoinBehavior>();
        player2.GetComponent<guardianAngelJoinBehavior>().onJoinSmacked += itsShowtime;
    }

    public void itsShowtime(object sender, EventArgs e)
    {
        print("its showtime!!!!");
        SceneManager.LoadScene("debugScene");
    }
}

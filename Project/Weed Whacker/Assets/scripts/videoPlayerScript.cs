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

        player1 = GameObject.Find("player 1");
        player1.GetComponent<playerScript>().attack.performed += itsShowtime;
        player1.GetComponent<playerScript>().startUpScreenOver = true;
        print("player 1's startupScreenOver boolean is currently: " + player1.GetComponent<playerScript>().startUpScreenOver);
        player2 = GameObject.Find("player 2");
        player2.GetComponent<playerScript>().attack.performed += itsShowtime;
        player2.GetComponent<playerScript>().startUpScreenOver = true;
        print("player 2's startupScreenOver boolean is currently: " + player2.GetComponent<playerScript>().startUpScreenOver);
    }

    public void itsShowtime(InputAction.CallbackContext context)
    {
        print("its showtime!!!!");
        //player1.GetComponent<playerScript>().attack.performed -= context => itsShowtime(context); //im actually not sure if unsubscribing is actually necessary, since this object is going to be destroyed after loading the scene... oh well! ^_^
        player1.GetComponent<playerScript>().attack.performed -= itsShowtime;
        player2.GetComponent<playerScript>().attack.performed -= itsShowtime;
        SceneManager.LoadScene("debugScene");
    }
}

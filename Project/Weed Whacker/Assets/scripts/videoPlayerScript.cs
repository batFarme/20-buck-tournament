using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class videoPlayerScript : MonoBehaviour
{
    public void Awake()
    {
        print("it did the thing");
        GameObject player1 = GameObject.Find("player 1 guardian angel");
        player1.AddComponent<guardianAngelJoinBehavior>();
        print(player1.GetComponent<guardianAngelJoinBehavior>().flagVar);
        //player1.GetComponent<guardianAngelJoinBehavior>().joinButtonSmacked.AddListener(itsShowtime);
        //player1.GetComponent<guardianAngelJoinBehavior>().joinButtonSmacked += itsShowtime;
        GameObject player2 = GameObject.Find("player 2 guardian angel");
        player2.AddComponent<guardianAngelJoinBehavior>();
        //player2.GetComponent<guardianAngelJoinBehavior>().joinButtonSmacked.AddListener(itsShowtime);
    }

    public void itsShowtime()
    {
        print("its showtime!!!!");
        SceneManager.LoadScene("debugScene");
    }
}

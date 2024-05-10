using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class hurtbox : MonoBehaviour
{
    public UnityEvent theyHitMeeeeeeeWaaahhhhhhh;  //using unity event here is fine cause theres like only ever gona b one subscriber and that can be set in the editor (i so badly wanna use C# events but its too late now :shrug:)
    public bool ignorePlayerDamage = true; //this should be set in the editor to false for weeds
    [HideInInspector] public GameObject objectThatJustHitMe;
    [HideInInspector] private int myLayer; //currently needs to be manually set in the editor cause i have no clue how to get this objects layer through code alone...

    private void Awake()
    {
        myLayer = transform.parent.gameObject.layer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hitbox"/* && collision.gameObject.layer != myLayer*/)  //for some reason unity just fucking ignores the .tag check here?????? and goes on to the next block of code????? hello??????????? TO-DO-FLAG-6
        {
            if (myLayer == 12) //for the flowers, so they dont get killed by players. honeslty, this solution is horrible since it adds a check for all entites that arent flowers, but this game could run on a caluclator anyways, so....
            {
                if (collision.gameObject.layer == 10)
                {
                    return;
                }
                else if (collision.gameObject.layer != myLayer)
                {
                    print(transform.parent.gameObject.name + "'s hurtbox was just smacked; my layer is " + myLayer + " and my attacker's layer is " + collision.gameObject.layer);
                    objectThatJustHitMe = collision.gameObject.transform.parent.gameObject; //WOW thats a lot of methods! good fucking bye performance!!!! :D
                    theyHitMeeeeeeeWaaahhhhhhh.Invoke();
                }
            }
            else if (collision.gameObject.layer != gameObject.layer)
            {
                print(transform.parent.gameObject.name + "'s hurtbox was just smacked; my layer is " + myLayer + " and my attacker's layer is " + collision.gameObject.layer);
                objectThatJustHitMe = collision.gameObject.transform.parent.gameObject; //WOW thats a lot of methods! good fucking bye performance!!!! :D
                theyHitMeeeeeeeWaaahhhhhhh.Invoke();
            }
            else
            {
                print("friendly fire on " + gameObject.name);
            }
        }
    }
}

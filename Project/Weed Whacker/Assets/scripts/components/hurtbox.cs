using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class hurtbox : MonoBehaviour
{
    public UnityEvent theyHitMeeeeeeeWaaahhhhhhh;
    [HideInInspector] public GameObject objectThatJustHitMe;
    public int myLayer; //currently needs to be manually set in the editor cause i have no clue how to get this objects layer through code alone...

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hitbox"/* && collision.gameObject.layer != myLayer*/)  //for some reason unity just fucking ignores the .tag check here?????? and goes on to the next block of code????? hello??????????? TO-DO-FLAG-6
        {
            if (collision.gameObject.layer != myLayer)
            {
                print("hurtbox was just smacked");
                objectThatJustHitMe = collision.gameObject.transform.parent.gameObject;
                theyHitMeeeeeeeWaaahhhhhhh.Invoke();
            }
            /*
            print("hurtbox was just smacked");
            objectThatJustHitMe = collision.gameObject.transform.parent.gameObject;
            theyHitMeeeeeeeWaaahhhhhhh.Invoke();
            */
        }
    }
}

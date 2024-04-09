using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class hurtbox : MonoBehaviour
{
    public GameObject mommy; // the parent object. needs to be set in editor. 

    public UnityEvent theyHitMeeeeeeeWaaahhhhhhh;
    [HideInInspector] public GameObject objectThatJustHitMe;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hitbox")
        {
            objectThatJustHitMe = collision.gameObject;
            theyHitMeeeeeeeWaaahhhhhhh.Invoke();
        }
    }
}

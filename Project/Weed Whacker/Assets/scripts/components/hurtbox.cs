using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class hurtbox : MonoBehaviour
{
    public GameObject mommy; // the parent object. 

    public UnityEvent theyHitMeeeeeeeWaaahhhhhhh;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hitbox")
        {
            theyHitMeeeeeeeWaaahhhhhhh.Invoke();
        }
    }
}

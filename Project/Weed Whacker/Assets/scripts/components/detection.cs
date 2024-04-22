using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;
public class detection : MonoBehaviour
{
    //references
    public GameObject myMommyWeehhhh;
    public Collider2D myCollider;

    private void Start()
    {
        //myCollider.IgnoreLayer
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hurtbox" && collision.gameObject.layer != LayerMask.NameToLayer("weed")) 
        {
            myMommyWeehhhh.GetComponent<Animator>().SetInteger("detectedTargets",
            myMommyWeehhhh.GetComponent<Animator>().GetInteger("detectedTargets") + 1);
            print("target acquired!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hurtbox" && collision.gameObject.layer != LayerMask.NameToLayer("weed"))
        {
            myMommyWeehhhh.GetComponent<Animator>().SetInteger("detectedTargets",
            myMommyWeehhhh.GetComponent<Animator>().GetInteger("detectedTargets") - 1);
        }
    }
}

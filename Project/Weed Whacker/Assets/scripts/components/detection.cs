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
    public UnityEvent gotchaBitch;

    private void Start()
    {
        //myCollider.IgnoreLayer
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hurtbox" && collision.gameObject.layer != LayerMask.NameToLayer("weed"))
        {
            print("target acquired!");
            gotchaBitch.Invoke();
        }
    }
}

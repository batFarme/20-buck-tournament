using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerDetection : MonoBehaviour
{
    //references


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hurtbox" && collision.gameObject.layer != LayerMask.NameToLayer("flower")) //now im prety sure i can just get rid of the NameToLayer method by replacing it with a straight up int thats set in the start function but. WHATEVER. TO-DO-7
        {
            //start the drinking animation
        }
    }

    //REMEMBER TO HAVE THE takeHit ANIMATION DISABLE THE DETECTION THINGY, so that if a flower gets smacked but wasnt smacked far enough to give it cause to move to do OnTriggerEnter2D again, it just..... yknow
}

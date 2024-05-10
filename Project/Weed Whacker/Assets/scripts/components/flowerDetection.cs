using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerDetection : MonoBehaviour
{
    //references
    public flowerScript theMainScriptSWE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "well")
        {
            print("i am touching well!");
            theMainScriptSWE.myAnimator.SetTrigger("flowerTouchWell");
        }
    }

    //REMEMBER TO HAVE THE takeHit ANIMATION DISABLE THE DETECTION THINGY, so that if a flower gets smacked but wasnt smacked far enough to give it cause to move to do OnTriggerEnter2D again, it just..... yknow
}

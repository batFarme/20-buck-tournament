using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;  //REMEMBER TO COMMENT OUT WHEN BUILDING

public class flowerScript : EntityClass, Ientity
{
    //references
    public GameObject theWell;
    public GameObject myHurtbox;
    [HideInInspector] public int myLayer;
    public AIPath myAIPath;
    public AIDestinationSetter myDstnSttr;
    public Animator myAnimator;
    //handling
    public float moveSpeed; //this is set by the game manager upon instantiation, so dw abt leaving it blank :shrug:

    // Start is called before the first frame update
    void Start()
    {
        onDeath += iDiedSadFace;
        myDstnSttr.target = theWell.transform;
        crntHp = maxHp;
    }

    public void iDiedSadFace(object sender, EventArgs e)
    {
        GameObject.Find("newGameManager").GetComponent<GamerManager>().allFlowers.Remove(gameObject);
        Destroy(gameObject);
    }

    public void imOuttaHereBucko()
    {
        Destroy(gameObject);
    }

    //no update function cause flowers do pretty much nothing unless acted upon; movement is handled by the pathfinding solution

}

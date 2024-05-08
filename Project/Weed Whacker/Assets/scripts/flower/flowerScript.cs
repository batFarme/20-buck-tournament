using Pathfinding;
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

    //handling
    public float moveSpeed; //this is set by the game manager upon instantiation, so dw abt leaving it blank :shrug:

    // Start is called before the first frame update
    void Start()
    {
        myDstnSttr.target = theWell.transform;
        crntHp = maxHp;
    }

    //no update function cause flowers do pretty much nothing unless acted upon; movement is handled by the pathfinding solution

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weedScript : MonoBehaviour, IWalkBehavior, Ientity
{
    //references
    public GameObject originalTarget;
    
    //handling
    public float moveSpeed;

    //internal controls
    private GameObject currentTarget;

    public void movement(float speed, Vector2 direction)
    {
        throw new System.NotImplementedException();
    }

    public void takeHit(int dmgTaken)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

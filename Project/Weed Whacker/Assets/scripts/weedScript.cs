using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class weedScript : MonoBehaviour, IWalkBehavior, Ientity
{
    //references
    [HideInInspector] public GameObject originalTarget;
    public Rigidbody2D myRigidbody2D;
    public GameObject myHitbox;
    public GameObject me;
    //handling
    public float moveSpeed;

    //internal controls
    private GameObject currentTarget;
    private Vector2 heading;
    private float distance;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        print("i am targeting " + originalTarget.name);
        currentTarget = originalTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget.transform.position.x > me.transform.position.x) //having sprite flipping run every frame like this proly tanks the performance but this whole game could run on a calculator, its fine :shrug:d
        {
            me.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            me.transform.localScale = new Vector3(-1, 1, 1);
        }

        heading = originalTarget.transform.position - myHitbox.transform.position;
        distance = heading.magnitude;
        direction = new Vector2(heading.x/distance, heading.y/distance);
        myRigidbody2D.velocity = direction;
    }

    public void linkCheck()
    {
        print("yes, linked!");
    }

    public void movement(float speed, Vector2 direction)
    {
        throw new System.NotImplementedException();
    }

    public void takeHit(GameObject attacker)
    {
        throw new System.NotImplementedException();
    }
}

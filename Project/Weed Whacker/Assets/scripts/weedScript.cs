using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Experimental.GraphView.GraphView;

public class weedScript : MonoBehaviour, IWalkBehavior, Ientity
{
    //references
    [HideInInspector] public GameObject originalTarget;
    public Rigidbody2D myRigidbody2D;
    public GameObject myHitbox;
    public GameObject myHurtbox;
    public GameObject myDetector;
    public GameObject me;
    public Animator myAnimator;
    private GameManager gameManager; //having each individual weed have its own reference is probably unhealthy, remember to experiment with having each weed be a child of a "hive mind controller" object TO-DO-FLAG-4

    //handling
    [HideInInspector] public float moveSpeed;
    public int myLayer;

    //internal controls
    private float crntMoveSpeed;
    private GameObject currentTarget;
    private EntityClass targetsScript;
    private Vector2 heading;
    private float distance;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        crntMoveSpeed = moveSpeed;
        print("i am targeting " + originalTarget.name);
        currentTarget = originalTarget;
        targetsScript = currentTarget.GetComponent<EntityClass>();
        if (targetsScript != null)
        {
            print("it workedd!");
        }
        targetsScript.tellStalkerToFuckOff.AddListener(findANewBitch);
        print(targetsScript.linkFlag);
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

        heading = originalTarget.transform.position - myHitbox.transform.position; //the vector from current position to target position
        distance = heading.magnitude / crntMoveSpeed; //the value used to normalize the vector is affected by moveSpeed to change weed's speed
        direction = new Vector2(heading.x/distance, heading.y/distance); //normalizes the vector, but instead of unit vector 
        myRigidbody2D.velocity = direction;
    }

    public void linkCheck()
    {
    }

    public void movement(float speed, Vector2 direction)
    {
        throw new System.NotImplementedException();
    }

    public void takeHit()
    {
        print("i, a weed, have been hit!?!?!?");
        throw new System.NotImplementedException();
    }

    public void sicEm()
    {
        print("im bout to fuck this bitch up");
        myAnimator.SetTrigger("sic em!!!");
    }

    public void findANewBitch()
    {
        originalTarget = gameManager.randomTarget();
        currentTarget = originalTarget;
    }

    public void setMyLayer()
    {
        myHurtbox.GetComponent<hurtbox>().myLayer = myLayer;
    }
}


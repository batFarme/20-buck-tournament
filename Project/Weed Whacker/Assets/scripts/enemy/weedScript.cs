using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView; //REMEMBER TO COMMENT OUT WHEN BUILDING
using UnityEngine;
using UnityEngine.InputSystem.XR;
//using static UnityEditor.Experimental.GraphView.GraphView; //REMEMBER TO COMMENT OUT WHEN BUILDING

public class weedScript : EntityClass, IWalkBehavior, Ientity
{
    //references
    [HideInInspector] public GameObject originalTarget;
    public AIPath myAIPath;
    public Seeker mySeeker;
    public AIDestinationSetter myDstnSttr;
    public Rigidbody2D myRigidbody2D;
    public GameObject myHitbox;
    public GameObject myHurtbox;
    public GameObject myDetector;
    public GameObject me;
    public Animator myAnimator;
    private GamerManager gameManager; //having each individual weed have its own reference is probably unhealthy, remember to experiment with having each weed be a child of a "hive mind controller" object TO-DO-FLAG-4

    //handling
    [HideInInspector] public float moveSpeed;
    public int myLayer;

    //internal controls
    private float crntMoveSpeed;
    private GameObject currentTarget;
    private Transform aiTarget; //YEAH OKAY WHATEVER UUUGHHH FINEEEEEEEEEEEEEEEEEEEEEEE
    private EntityClass targetsScript;
    private Vector2 heading;
    private float distance;
    private Vector2 direction;
    private enum SideSwitch {
        left,
        right
    }
    private SideSwitch currentFace;    // its a shit fix, but whatever. a better fix would to have a custom movement script that would send out an event whenever it has to switch directions to the side switching function so that it doesnt have to check every frame, but thats kind of infeasible cause im using a* and theres no way im making a custom pathfinding solution in a reasonable amount of time, so yeah lets check using a custom method every frame, why not?

    // Start is called before the first frame update
    void Start()
    {
        crntMoveSpeed = moveSpeed;
        myAIPath.maxSpeed = crntMoveSpeed;
        print("i am targeting " + originalTarget.name);
        currentTarget = originalTarget;
        targetsScript = currentTarget.GetComponent<EntityClass>();
        //targetsScript.tellStalkerToFuckOff.AddListener(findANewBitch);
        print(targetsScript.linkFlag);
        aiTarget = currentTarget.transform;
        myDstnSttr.target = aiTarget;
        onDeath += deadAhhHell;
        crntHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget.transform.position.x > transform.position.x) //if the target is to the right...
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void linkCheck()
    {
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
        aiTarget = currentTarget.transform;
        myDstnSttr.target = aiTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void deadAhhHell(object sender, EventArgs e)
    {
        myAnimator.SetTrigger("AAAAHHHHHHH I FUCKING DIED");
        myDstnSttr.enabled = false;// im gona b so fr dawg i actually do not know what each of these do :skull: im just using public libraries i have NO clue how these work :sob: :sob: :sob:
        myAIPath.enabled = false;
        mySeeker.enabled = false;
    }

    public void myFinalMessage()
    {
        GameObject.Destroy(this.gameObject);
    }

    //below block of code is made obsolete by pathfinding system, but keep it just in case...
    public void movement(float speed, Vector2 direction) //direction is the current target's coordinates rather than a regular vector; its still labelled as direction because of how interfaces work and tbh i cannot be bothered to mess with it any more 
    {
        distance = direction.magnitude / crntMoveSpeed; //the value used to normalize the vector is affected by moveSpeed to change weed's speed
        direction = new Vector2(direction.x / distance, direction.y / distance); //normalizes the vector, but instead of unit vector 
        myRigidbody2D.velocity = direction;
    }
}


using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView; //REMEMBER TO COMMENT OUT WHEN BUILDING
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Experimental.GraphView.GraphView; //REMEMBER TO COMMENT OUT WHEN BUILDING

public class weedScript : MonoBehaviour, IWalkBehavior, Ientity
{
    //references
    [HideInInspector] public GameObject originalTarget;
    public AIPath myAIPath;
    public Rigidbody2D myRigidbody2D;
    public GameObject myHitbox;
    public GameObject myHurtbox;
    public GameObject myDetector;
    public GameObject me;
    public Animator myAnimator;
    private GameManager gameManager; //having each individual weed have its own reference is probably unhealthy, remember to experiment with having each weed be a child of a "hive mind controller" object TO-DO-FLAG-4
    public AIDestinationSetter myDstnSttr;

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
    }

    // Update is called once per frame
    void Update()
    {
        /*
        SideSwitch whereIsTarget = sideCheck(currentTarget);
        if (whereIsTarget != currentFace) //having sprite flipping run every frame like this proly tanks the performance but this whole game could run on a calculator, its fine :shrug: ; also btw there are two variables serving the same purpose, currentTarget and aiTarger, i could probably fix it but idrc anymore.
        {
            transform.position = flipPoint.transform.position;
            if (whereIsTarget == SideSwitch.left)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            currentFace = whereIsTarget;
        }
        */

        if (currentTarget.transform.position.x > transform.position.x) //if the target is to the right...
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //this movement line is made obsolete by the a* algorithm thing
        //movement(crntMoveSpeed, originalTarget.transform.position - myHitbox.transform.position);
    }
    /*
    private SideSwitch sideCheck(GameObject objToCheck)
    {
        if (objToCheck.transform.position.x > flipPoint.transform.position.x) //if the thing i am checking is to the right....
        {
            return SideSwitch.right;
        }
        else
        {
            return SideSwitch.left;
        }
    }
    */
    public void linkCheck()
    {
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
        aiTarget = currentTarget.transform;
        myDstnSttr.target = aiTarget;
    }

    public void setMyLayer()
    {
        myHurtbox.GetComponent<hurtbox>().myLayer = myLayer;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    //below block of code is made obsolete by pathfinding system, but keep it just in case...
    public void movement(float speed, Vector2 direction) //direction is the current target's coordinates rather than a regular vector; its still labelled as direction because of how interfaces work and tbh i cannot be bothered to mess with it any more 
    {
        distance = direction.magnitude / crntMoveSpeed; //the value used to normalize the vector is affected by moveSpeed to change weed's speed
        direction = new Vector2(direction.x / distance, direction.y / distance); //normalizes the vector, but instead of unit vector 
        myRigidbody2D.velocity = direction;
    }
}


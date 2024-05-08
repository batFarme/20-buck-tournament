using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wellScript : EntityClass, Ientity
{
    public CapsuleCollider2D myCapsuleCollider2D;

    public void Start()
    {
        crntHp = maxHp;
    }

    public void setMyLayer()
    {
        throw new System.NotImplementedException();
    }

    /*
    public void takeHit()
    {
        throw new System.NotImplementedException();
    }
    */
}

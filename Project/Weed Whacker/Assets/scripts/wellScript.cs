using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wellScript : EntityClass, Ientity
{
    public CapsuleCollider2D myCapsuleCollider2D;
    

    public void Start()
    {
        onHit += wellReportDamages;
        crntHp = maxHp;
    }

    public void setMyLayer()
    {
        throw new System.NotImplementedException();
    }

    public void wellReportDamages(object sender, EventArgs e)
    {
        print("well health is now " + crntHp + "!");
    }
}

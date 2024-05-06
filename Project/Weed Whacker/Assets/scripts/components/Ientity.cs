using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ientity
{
    public void takeHit();
    public void setMyLayer(); //used in conjunction with hurtbox to prevent friendly fire
}

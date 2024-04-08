using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWalkBehavior
{
    public void movement(float speed, Vector2 direction);
}

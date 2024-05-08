using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityClass : MonoBehaviour
{
    public int maxHp;
    public int crntHp;

    [HideInInspector] public event EventHandler tellStalkerToFuckOff; //for flowers and players, so that when killed or knocked, any weeds following them fucking die
    [HideInInspector] public event EventHandler onHit; //for if the entity in question does specific things when struck; any associated functions should be set IN THE EDITOR
    [HideInInspector] public event EventHandler onDeath; //same as onHit, but for death
    [HideInInspector] public string linkFlag = "yes, the link works!"; //used for debugging.

    public void takeHit() //this bit here handles the hp stuff, and invoking death and hit stuff
    {
        if (crntHp > 0)
        {
            print("aw fuck someone hit me!!!!");
            crntHp--; //no need to check damage value, since all damage universally is one point
            if (crntHp <= 0)
            {
                onDeath?.Invoke(this, EventArgs.Empty);
                print("im super dead!");
            }
            else
            {
                onHit?.Invoke(this, EventArgs.Empty);
                //also do some stuff for getting hit but also... maybe just do that shit in the animator? food for thought TO-DO-FLAG-5
            }
        }
    }

    public void tellStalkersToGoAway() //for some reason, C# doesnt like events being invoked outside of the original script, *even when the script trying to invoke it inherits the script that contains the event.* so to fix this, this function has been made. microsoft, pls fix
    {
        tellStalkerToFuckOff?.Invoke(this, EventArgs.Empty);
    }
}

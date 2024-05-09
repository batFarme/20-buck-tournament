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
        //print("aw fuck someone hit me!!!! i am: " + gameObject.name + " and now I have " + crntHp + " health remaining!");
        if (crntHp > 0)
        {
            crntHp--;
            onHit?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            tellStalkersToGoAway();
            StartCoroutine(yodaDeathNoiseCoroutine()); // so theres a coroutine here so that any weeds targeting this object have time to unsubscribe to the event, avoiding any null reference exceptions; im sure theres a far better way to do it with like ordering code n shit but that's beyond the scope of this project :shrug:
            /*
            onDeath?.Invoke(this, EventArgs.Empty);
            print("im super dead! i was " + gameObject.name);
            */
        }
    }

    public IEnumerator yodaDeathNoiseCoroutine()
    {
        yield return new WaitForSeconds(.1f);
        onDeath?.Invoke(this, EventArgs.Empty); //rather than have a Destroy(self) here, instead leave it up to different entities to decide what exactly to do upon death.
        print("im super dead! i was " + gameObject.name);
    }

    public void tellStalkersToGoAway() //for some reason, C# doesnt like events being invoked outside of the original script, *even when the script trying to invoke it inherits the script that contains the event.* so to fix this, this function has been made. microsoft, pls fix
    {
        tellStalkerToFuckOff?.Invoke(this, EventArgs.Empty);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityClass : MonoBehaviour
{
    [HideInInspector] public event EventHandler tellStalkerToFuckOff;
    public string linkFlag = "yes, the link works!"; //used for debugging.
    public void tellStalkersToGoAway() //for some reason, C# doesnt like events being invoked outside of the original script, *even when the script trying to invoke it inherits the script that contains the event.* so to fix this, this function has been made. microsoft, pls fix
    {
        tellStalkerToFuckOff?.Invoke(this, EventArgs.Empty);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//so! im gonna have blake drag and drop all the audio clips here, then probably have each gameObject that wants to emit noise have a reference to this script and hten pull each sound from it; this does add some more loading time, but its negligible :shrug:

public class soundEffects : MonoBehaviour
{
    public AudioClip playerHit; 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {

    public delegate void KillHandler();
    public static event KillHandler onKill; //An event 
    
    public AudioSource audio;

    void OnTriggerEnter2D(Collider2D col) //A Unity event. Called when two colliders with isTrigger is touched
    {
        if (col.tag == "Player") //Use tags to check for player in case there are other collisions in the game like pick ups
        {
            audio.Play();
            onKill(); //Invokes the event when pipe collides with player        
        }
    }
}

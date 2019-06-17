using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    public AudioSource audio;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            audio.Play();
            Score.instance.AddScore(1); 
        }
    }
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdController : MonoBehaviour {

    public float flapPower;
    public float flapRotation; // Z Axis rotation of bird when flapping
    public float fallRotation; // Z Axis rotation of bird when falling
    public float ratationSpeed; 
    bool movementDisabled;

    public AudioClip deathSoundEffect; //The audio clip from music folder
    public AudioClip flapSoundEffect;

    Rigidbody2D rb; //The rigidbody2D component attached to flappybird
    Animator anim; //The Animator component attached to flappybird
    AudioSource audio; // The AudioSourse component attached to flappybird, will be used to play the audio clip

    void Awake() //happens before Start()
    {
        movementDisabled = false;
        Kill.onKill += OnDeath; //subscribe our OnDeath function to the onKill event
    }

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>(); //Gets reference to flappybird's RigidBody2D once the game starts
        anim = GetComponent<Animator>();  //Gets reference to flappybird's Animator once the game starts
        audio = GetComponent<AudioSource>(); //Gets reference to flappybird's AudioSource once the game starts
    }

    // Update is called once per frame 
    void Update() {
        if (movementDisabled) //return from the update function if movement is disabled so we can't take input anymore
            return;

        if (Input.GetKeyDown(KeyCode.Space)) //If spacebar is pressed down // Calls once when pressed down
        {
            audio.clip = flapSoundEffect;
            audio.Play();
            rb.velocity = new Vector2(rb.velocity.x, flapPower); //Adds an upward velocity to the Rigidbody
        }

        SetAnim();
        SetTilt();
    }

    void OnDeath() //the onDeath event will trigger this function
    {
        audio.clip = deathSoundEffect;
        audio.Play();
        movementDisabled = true;
        transform.rotation = Quaternion.Euler(0, 0, fallRotation);
        GetComponent<BoxCollider2D>().enabled = false; // We dont want flappybird to touch the AddScore box Collider when it dies
    }

    void OnDestroy()
    {
        Kill.onKill -= OnDeath; //Unsubscribe when gameobject is destroyed
    }

    void SetAnim()
    {
        anim.SetFloat("YVelocity", rb.velocity.y); //Sets animator's Yvelocity to the RigidBody2D's Y velocity
    }

    void SetTilt()
    {
        if (rb.velocity.y <= 0) 
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, fallRotation), Time.deltaTime * ratationSpeed);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, flapRotation);
        }
    }
}

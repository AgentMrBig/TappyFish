using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    // Audio
    public AudioClip playerDie;
    public AudioClip swim;

    // NEW non physics
    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 flapVelocity;
    public float maxSpeed = 3f;
    public float forwardSpeed = 1f;

    private PlayerController controller;
    Animator animator;

    bool didSwim = false;

    void Start()
    {
        
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        flapVelocity = new Vector3(0, 2, 0);
        gravity = new Vector3(0, -1, 0);

    }

	// Update is called once per frame
	void Update () {  
        if (GameMaster.playerIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                didSwim = true;
                SwimSound();
                
            }
        }

        if (GameMaster.playerIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                
            }
        }
    }

    void FixedUpdate()
    {

        Swim();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Player Triggered: " + collider.name +". tagged: " + collider.tag);
        if (collider.tag == "Ground" || collider.tag == "Deadly")
        {
            DieSound();
            gravity = new Vector3(0, 0, 0);
            velocity = new Vector3(0, 0, 0);
            Debug.Log("Player Alive: " + GameMaster.playerIsAlive);
            GameMaster.playerIsAlive = false;
            animator.SetInteger("BodyAnimState", 1);
            Debug.Log("Player Alive: " + GameMaster.playerIsAlive);
        }
        
    }

    void DieSound()
    {
        AudioSource.PlayClipAtPoint(playerDie, transform.position);
    }

    void SwimSound()
    {
        AudioSource.PlayClipAtPoint(swim, transform.position);
    }

    void Swim()
    {
        velocity.x = forwardSpeed;
        velocity += gravity * Time.deltaTime;

        if (didSwim)
        {
            didSwim = false;
            // cancel any downward velocity upon flap
            //if (velocity.y < 0)
            //{
            //    velocity.y = 0;
            //}
            velocity += flapVelocity;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime;

        // Lerp rotate down when faling and up when swimming
        float angle = 0;
        if (velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -90, -velocity.y / maxSpeed);
        }
        if (velocity.y > 0)
        {
            angle = Mathf.Lerp(GameMaster.lastPlayerRot.z, 90, velocity.y / maxSpeed);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);

        
    }

        
}


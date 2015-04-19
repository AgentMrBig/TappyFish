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

	public int flippity = 1;
	public int fliptime = 0;

    private PlayerController controller;
    Animator animator;

    bool didSwim = false;

    void Start()
    {
        
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        flapVelocity = new Vector3(0, 3, 0);
        gravity = new Vector3(0, -2, 0);
		//flippity = false;

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

		

			if (Input.GetKeyDown(KeyCode.Q))                       //************************Executes Flip and applies gravity change [JC]
				{
				flippity = 7;
				fliptime = 0;
				//forwardSpeed = 2f;
				gravity = new Vector3(0, -6, 0);
				//flapVelocity = new Vector3(0, 3, 0);
//				//forwardSpeed = 1f;
//				didSwim = true;
//				SwimSound();
					
				}
				if (Input.GetKeyUp(KeyCode.Q))
				{
				//forwardSpeed = 1f;
				//flapVelocity = new Vector3(0, 3, 0);
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

		if (didSwim) {
			didSwim = false;
			// cancel any downward velocity upon flap
			//if (velocity.y < 0)
			//{
			//    velocity.y = 0;
			//}
			velocity += flapVelocity;
		}

		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);

		transform.position += velocity * Time.deltaTime;

		// Lerp rotate down when faling and up when swimming
		{
			float angle = 0;
			if (velocity.y < 0) {
				angle = Mathf.Lerp (0, -90, -velocity.y / maxSpeed);

				transform.rotation = Quaternion.Euler (0, 0, angle);
			}
			if (velocity.y > 0) {
				angle = Mathf.Lerp (GameMaster.lastPlayerRot.z, 90, velocity.y / maxSpeed);
				transform.rotation = Quaternion.Euler (0, 0, angle);
			}


//		if (flip = false)
//		{
//			//transform.rotation = Quaternion.Euler(0, 0, angle);
//			transform.rotation = Quaternion.Euler(0, 0, angle);
//		}



		}
		if (flippity > 6)                                             //************************Flips the player fish around  [JC]
		{
			fliptime = fliptime + 8;
//			if (fliptime < 180)
//				{
//				gravity = new Vector3(0, 2, 0);
//				}
//			if (fliptime < 180 || fliptime < 360)
//			{
//				gravity = new Vector3(0, -2, 0);
//			}
			transform.rotation = Quaternion.Euler(0, 0, fliptime);
			//transform.rotation = Quaternion.Euler(0, 0, 180);
			
			if (fliptime > 270)
			{
				flippity = 1;
				gravity = new Vector3(0, -2, 0);
			}
			
		}
	}
        
}


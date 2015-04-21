using UnityEngine;
using System.Collections;

public class BlackJelly : MonoBehaviour {
	public AudioClip attackSound;
	float speed = -4f;
	float swimSpeed = 0f;
	bool isAlive = true;
	bool swimUp = true;
	
	public float topY = 7f;
	public float bottomY = 0.48f;
	public Vector3 currentPos;
	public Quaternion currentRot;
	
	private float duration = 1f;
	
	public int timeLoop = 0;
	
	public Vector3 firstPos;
	public float topSwimLimit;
	public float bottomSwimLimit;
	
	// Use this for initialization
	void Awake () {
		firstPos = transform.position;
		topSwimLimit = firstPos.y + 3f;
		bottomSwimLimit = firstPos.y - 3f;
		
	}
	
	// Update is called once per frame
	void Update () {
		//currentPos = transform.position;
		//currentRot = transform.rotation;
		
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{      
		
		
		JellySwim();
	}
	
	void JellySwim()
	{
		
		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;
		pos.x += speed * Time.deltaTime;
		
		if (pos.y >= topY || pos.y >= topSwimLimit )
		{
			swimUp = false;
		}
		
		if (pos.y <= bottomY || pos.y <= bottomSwimLimit)
		{
			swimUp = true;
		}
		
		
		if (swimUp)
		{
			//Debug.Log("travelUp = true");
			pos.y += swimSpeed * Time.deltaTime;
			transform.position = pos;
		}
		else
		{
			//Debug.Log("travelUp = false");
			pos.y += -swimSpeed * Time.deltaTime;
			transform.position = pos;
		}
	}
	
	void DeathTimer(float timeRemaining = 8f)
	{
		timeLoop++;
		timeRemaining -= Time.deltaTime;
		
		if (timeRemaining > 0)
		{
			
		}
		else
		{
			Destroy(gameObject);
			//Debug.Log("Timer Loop Reset" + "timer was " + randomTimer);
		}
	}
}

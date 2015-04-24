using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	public AudioClip attackSound;
	public float horizontalspeed = 2f;
	public float verticalspeed = 0.5f;
	bool isAlive = true;
	bool swimUp = true;
	
	public float topY = 7f;
	public float bottomY = 0.5f;
	public int type = 1;                      //************************ 1 for single, 2 for group[JC]
	private Vector3 currentPos;
	private Quaternion currentRot;
	
	private float duration = 1f;
	
	private int timeLoop = 0;

	private Vector3 firstPos;
	private float topSwimLimit;
	private float bottomSwimLimit;
	
	// Use this for initialization
	void Awake () {
		firstPos = transform.position;
		topSwimLimit = firstPos.y + 3f;
		bottomSwimLimit = firstPos.y - 3f;
		if (type > 1)                          //************************ keep grouped units close together [JC]
		{
			topSwimLimit = firstPos.y + 1f; 
			bottomSwimLimit = firstPos.y - 1f;
		}
		
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
		pos.x -= horizontalspeed * Time.deltaTime;
		
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
			pos.y += verticalspeed * Time.deltaTime;
			transform.position = pos;
		}
		else
		{
			//Debug.Log("travelUp = false");
			pos.y += -verticalspeed * Time.deltaTime;
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

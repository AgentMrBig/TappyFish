using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
    public int coinValue = 1;
    public AudioClip pickupSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") 
		{
            GameMaster.currentScore += coinValue;

            if (pickupSound)
            {
                coinSound();
            }
            
			Destroy (gameObject);
		}
	}

    void coinSound()
    {
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
    }
}

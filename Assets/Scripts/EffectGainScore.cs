using UnityEngine;
using System.Collections;

public class EffectGainScore : MonoBehaviour {
    //************************* This is the script for the floating points affect when touching a pickup
    // the alpha fade is handled on each of the sprite characters (+10) with the Disapear.cs script and the parent
    // game object destroyed after lifespan reaches zero here, the isntantiation of the floating points effect is
    // done from the player prefab via oncollision2d and based on gameobject tag, acording to the tag, different point
    // effects will be instantiated **** Added an intial bulge effect, and then shrinks as well as fades

    private float startYScale = 1.3f;
    private float startXScale = 1.3f;
    private float duration = 4f;

    Vector3 upVel = Vector3.zero;
    public float pointsUpSpeed = 0.5f;
    public float lifeSpan = 4f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        upVel.y = pointsUpSpeed * Time.deltaTime;
        transform.position += upVel;
        lifeSpan -= 1f * Time.deltaTime;

        startYScale -= 0.1f * Time.deltaTime;
        startXScale -= 0.1f * Time.deltaTime;
    
        transform.localScale = new Vector3(startXScale, startYScale, transform.localScale.z);

        if (lifeSpan <= 0)
        {
            Destroy(gameObject); 
        }
	}
}

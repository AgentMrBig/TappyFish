using UnityEngine;
using System.Collections;

public class FloatEffect2 : MonoBehaviour {

    private float startY = -6.42f;
    private float startX = -0.38f;
    private float duration = 3.2f;

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        float newY = 9f + (startY + Mathf.Cos(Time.time / duration)) / 4;
        transform.position = new Vector2(transform.position.x, newY);

        //float newX = startX + (startX + Mathf.Cos(Time.time / duration)) / 2;
        //transform.position = new Vector2(transform.position.y, newX);
	}
}

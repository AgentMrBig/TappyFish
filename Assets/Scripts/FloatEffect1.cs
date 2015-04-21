using UnityEngine;
using System.Collections;

public class FloatEffect1 : MonoBehaviour {

    private float startY = -5.28f;
    private float startX = -0.38f;
    private float duration = 5f;

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        float newY = 10f + (startY + Mathf.Cos(Time.time / duration)) / 4;
        transform.position = new Vector2(transform.position.x, newY);


        //float newX = startX + (startX + Mathf.Cos(Time.time / duration)) / 2;
        //transform.position = new Vector2(transform.position.y, newX);
	}
}

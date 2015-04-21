using UnityEngine;
using System.Collections;

public class DieMessageEffects : MonoBehaviour {

    private float startYScale = 5.7f;
    private float startXScale = 16.2f;
    private float duration = 0.3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        float newY = 7f + (startYScale + Mathf.Cos(Time.time / duration));
        float newX = 18f + (startXScale + Mathf.Cos(Time.time / duration));
        //transform.position = new Vector2(transform.position.x, newY);
        transform.localScale = new Vector3(newX, newY, transform.localScale.z);

        //float newX = startX + (startX + Mathf.Cos(Time.time / duration)) / 2;
        //transform.position = new Vector2(transform.position.y, newX);
	}
}

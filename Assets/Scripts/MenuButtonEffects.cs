using UnityEngine;
using System.Collections;

public class MenuButtonEffects : MonoBehaviour {

    private float startYScale = 5f;
    private float startXScale = 15f;
    private float duration = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float newY = 5.2f + (startYScale + Mathf.Cos(Time.time / duration)) - 3;
        float newX = 15.2f + (startXScale + Mathf.Cos(Time.time / duration)) - 4;
        //transform.position = new Vector2(transform.position.x, newY);
        transform.localScale = new Vector3(newX, newY, transform.localScale.z);

        //float newX = startX + (startX + Mathf.Cos(Time.time / duration)) / 2;
        //transform.position = new Vector2(transform.position.y, newX);
    }
}

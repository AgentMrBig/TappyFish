using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour {

    float speed = -2f;

	void FixedUpdate () 
    {
        if (GameMaster.playerIsAlive)
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
        }
        
	}
}

using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

    int numBGPanels = 7;

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.tag != "Pickup")
        {
            float widthOfBGObjects = ((BoxCollider2D)collider).size.x;

            Vector3 pos = collider.transform.position;

            pos.x += widthOfBGObjects * numBGPanels - widthOfBGObjects / 2f;
			//pos.x = pos.x - 2;

            collider.transform.position = pos;
        }

        

        if (collider.tag == "Coin" || collider.tag == "Deadly" || collider.tag == "Pickup")
        {
            Destroy(collider);
        }
    }
}

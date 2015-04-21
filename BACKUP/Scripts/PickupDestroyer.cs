using UnityEngine;
using System.Collections;

public class PickupDestroyer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Pickup" || collider.tag == "Deadly")
        {
            Debug.Log("Destroyer Triggered by: " + collider.tag);
            Destroy(collider.gameObject);
        }
    }
}

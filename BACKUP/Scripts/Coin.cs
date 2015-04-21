using UnityEngine;
using System.Collections;


public class Coin : MonoBehaviour
{
    public AudioClip pickupSound;
    public int coinValue = 10;

    float speed = -2f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameMaster.playerIsAlive)
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameMaster.currentScore += coinValue;
            coinSound();
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "PickupDestroyer")
        {
            Destroy(gameObject);
        }
    }

    void coinSound()
    {
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
    }

}

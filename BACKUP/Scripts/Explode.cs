using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
    public AudioClip dieSound;
    public BodyPart bodyPart;
    public int totalParts = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
			Debug.Log ("Touched Deadly");
            OnExplode();
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Deadly")
        {
            Debug.Log("Touched Deadly");
            OnExplode();
        }
    }

    void PlayDieSound()
    {
        if (dieSound)
        {
            AudioSource.PlayClipAtPoint(dieSound, transform.position);
        }
        
    }


    void OnExplode() {
        Destroy(gameObject);
        if (this.name == "Player")
        {
            GameMaster.playerIsAlive = false;
            PlayDieSound();
        }
        var t = transform;

        // Applying force to all the body parts
        for (int i = 0; i < totalParts; i++)
        {
            t.TransformPoint(0, -100, 0);
            BodyPart clone = Instantiate(bodyPart, t.position, Quaternion.identity) as BodyPart;

            // Random left or right force to body part
            clone.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-100, 100));

            // Random strength force in up direction for body part
            clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(100, 150));
        }

       // GameObject go = new GameObject("ClickToContinue");
       // ClickToContinue script = go.AddComponent<ClickToContinue>();
       // script.scene = Application.loadedLevelName;
    }
}

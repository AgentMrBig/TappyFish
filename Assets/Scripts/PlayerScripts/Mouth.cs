using UnityEngine;
using System.Collections;

public class Mouth : MonoBehaviour {
    private PlayerController controller;
    Animator animator;

	// Use this for initialization
	void Start () 
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameMaster.playerIsAlive)
        {
            animator.SetInteger("MouthAnimState", 1);
        }
        else if (!GameMaster.playerIsAlive)
        {
            animator.SetInteger("MouthAnimState", 0);
        }
	
	}
}

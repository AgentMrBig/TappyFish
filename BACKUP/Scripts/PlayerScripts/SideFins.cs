using UnityEngine;
using System.Collections;

public class SideFins : MonoBehaviour {
    public Animator animator;
    private PlayerController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameMaster.playerIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (GameMaster.playerIsAlive)
                {
                    animator.SetInteger("SideFinsAnimState", 1);
                }
                
            }
        }
        else if (!GameMaster.playerIsAlive)
        {
            animator.SetInteger("SideFinsAnimState", 0);
        }
	
	}

    
}

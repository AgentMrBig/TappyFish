using UnityEngine;
using System.Collections;

public class MenuStart : MonoBehaviour {

    public string scene;
    private bool loadLock;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("Start button was clicked!");
        LoadScene();
    }

    void LoadScene()
    {
        loadLock = true;
        GameMaster.playerIsAlive = true;
        Application.LoadLevel(scene);
    }
}

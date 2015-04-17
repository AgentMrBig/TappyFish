using UnityEngine;
using System.Collections;

public class ClickToContinue : MonoBehaviour {

    public string scene;

    public Vector3 mousePos;

    private bool loadLock;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_IPHONE
        // --- IPHONE TOUCH ---
        // Code for OnMouseDown touch events on mobile
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {
                // Construct a ray from the current touch Coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
            }
            if (Physics.Raycast(ray, out hit))
            {
                hit.transform.gameObject.SendMessage("OnMouseDown");
            }
        }
#endif
         // Load scene via mouse click or button press

        if (Input.GetMouseButtonDown(0) && !loadLock)
        {
            LoadScene();
        }
        if (Input.GetKey("joystick button 0") && !loadLock)
        {
            LoadScene();
        }
	}


    void LoadScene()
    {
        loadLock = true;
        GameMaster.playerIsAlive = true;
        Application.LoadLevel(scene);
    }
}

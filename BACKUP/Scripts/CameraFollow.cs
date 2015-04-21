using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float camOffset = -5f;

    private Transform _t;

    //This calculation insures that the pixel ratio is as desired, 100f is each "block" is 100px
    private float screenCalc = ((Screen.height / 2.0f) / 50f);

    void Awake()
    {
        target = GameObject.Find("Player");
        Camera.main.orthographicSize = screenCalc;
    }

    // Use this for initialization
    void Start()
    {
        _t = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_t)
            transform.position = new Vector3(_t.position.x - camOffset, 2.5f, -10f);
    }
}

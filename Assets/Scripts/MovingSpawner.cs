using UnityEngine;
using System.Collections;

public class MovingSpawner : MonoBehaviour {
    // This script works by putting the spawner at topY to begin with
    private float topY = 7f;
    private float bottomY = 0.48f;
    private Vector3 currentPos;
    private Quaternion currentRot;
    private float startX = 8f;
    private float duration = 1f;

    // Timer
    public  float timeRemaining = 5f;
    public int timeLoop = 0;
    public float randomTimer;

    public Coin coin;
    public BlueJelly blueJelly;

    public float travelSpeed = 1f;

    private bool travelUp;

    // Use this for initialization
    void Start()
    {
        //spawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        currentRot = transform.rotation;

        

        //spawnBounce();
        //spawnCoin();
        var randomTimer = Random.Range(0f, 10f);
        var ranPosNum = Random.Range(7f, 0.48f);

        RandomYPos();

        AltTimer(randomTimer);


    }

    void spawnBounce()
    {
        
        if (currentPos.y >= topY)
        {
            travelUp = false;
            
        }

        if (currentPos.y <= bottomY)
        {
            travelUp = true;
        }

        if (travelUp)
        {
            //Debug.Log("travelUp = true");
            currentPos.y += travelSpeed * Time.deltaTime;
            transform.position = currentPos;
        }
        else
        {
            //Debug.Log("travelUp = false");
            currentPos.y += -travelSpeed * Time.deltaTime;
            transform.position = currentPos;
        }
    }

    void spawnCoin()
    {

        //StartCoroutine("WaitRandom");
    }

    IEnumerator WaitRandom()
    {
        var randomNum = Random.Range(0, 10);
        Instantiate(coin, currentPos, currentRot);
        yield return new WaitForSeconds(randomNum);
    }

    void RandomYPos()
    {
        var randomNum = Random.Range(7f, 0.48f);
        currentPos.y = randomNum;
        transform.position = currentPos;
    }

    IEnumerator RanYPos(float ranPosNum)
    {
       // var randomNum = Random.Range(7f, 0.48f);
        currentPos.y = ranPosNum;
        transform.position = currentPos;
        yield return new WaitForSeconds(0.5f);
    }

    void AltTimer(float timeRemaining = 5f)
    {
        timeLoop++;
        timeRemaining -= Time.deltaTime;

        if (timeRemaining > 0)
        {

        }
        else
        {
            Instantiate(coin, currentPos, currentRot);
            Instantiate(blueJelly, currentPos, currentRot);
            Debug.Log("Timer Loop Reset" + "timer was " + randomTimer);
        }
    }

}

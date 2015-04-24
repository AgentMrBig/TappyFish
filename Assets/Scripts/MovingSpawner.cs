﻿using UnityEngine;
using System.Collections;

public class MovingSpawner : MonoBehaviour {
    // This script works by putting the spawner at topY to begin with
    private float topY = 7f;
    private float bottomY = 0.48f;
    private Vector3 currentPos;
    private Quaternion currentRot;
    private float startX = 8f;
    private float duration = 1f;

	private int wavetime = 600;
	public int wavelength = 20; //******************Set the length of the wave in seconds[JC]

	//private int spawnratebluejelly = 3;
	//private int spawnratecoin = 1;

	private int spawntimercoin = 60;
	private int spawntimerredjelly = 400;
	private int spawntimerbluejelly = 200;
	private int spawntimergreenjelly = 600;
	private int spawntimerpurplejelly = 900;
	private int spawntimerblackjelly = 1200;
	private int spawntimertopcoral = 75;
	private int spawntimerfloor = 30;
	private int spawntimercrystalgreen = 90;
	private int spawntimerjellyswarm = 60;

	private int spawntimercoinwave = 60;
	private int spawntimerbluejellywave = 240;
	private int spawntimerredjellywave = 420;
	private int spawntimergreenjellywave = 540;
	private int spawntimerpurplejellywave = 660;
	private int spawntimerblackjellywave = 780;
	private int spawntimertopcoralwave = 75;
	private int spawntimerfloorwave = 100;
	private int spawntimercrystalgreenwave = 590;
	private int spawntimerjellyswarmwave = 700;

	private float spawnpositioncoin = 3;
	private float spawnpositionbluejelly = 3;
	private float spawnpositionredjelly = 3;
	private float spawnpositiongreenjelly = 3;
	private float spawnpositionpurplejelly = 3;
	private float spawnpositionblackjelly = 3;
	private float spawnpositiontopcoral = 6;
	private float spawnpositionfloor = 0;
	private float spawnpositioncrystalgreen = 3;
	private float spawnpositionjellyswarm = 3;

	//private 

    // Timer
    private  float timeRemaining = 5f;
    private int timeLoop = 0;
    private float randomTimer;
    
    public Unit bluejelly;
	public Unit redjelly;
	public Unit greenjelly;
	public Unit purplejelly;
	public Unit blackjelly;
	public Unit jellyswarm;
	public Unit topcoral;
	public Unit floor;
	public Coin crystalgreen;

    // Pickups and Collectables
    public Coin coin;
//    public GreenCrystal greenCrystal;
//    public BlueCrystal blueCrystal;
//    public ClearCrystal clearCrystal;
//    public YellowCrystal yellowCrystal;
//    public OrangeCrystal orangeCrystal;
//    public PinkCrystal pinkCrystal;

    public float travelSpeed = 6f;

    private bool travelUp;

    // Use this for initialization
    void Start()
    {
        //spawnCoin();
		wavelength = wavelength * 60;  //*******************Converts wavelength from frames to seconds [JC]
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentPos = transform.position;
        currentRot = transform.rotation;
		//spawnposition = transform.rotation;

		spawntimercoin = spawntimercoin - 1;
		spawntimerbluejelly = spawntimerbluejelly - 1;
		spawntimerredjelly = spawntimerredjelly - 1;
		spawntimergreenjelly = spawntimergreenjelly - 1;
		spawntimerpurplejelly = spawntimerpurplejelly - 1;
		spawntimerblackjelly = spawntimerblackjelly - 1;
		spawntimerjellyswarm -= 1;
		spawntimertopcoral = spawntimertopcoral - 1;
		spawntimerfloor = spawntimerfloor - 1;
		spawntimercrystalgreen -= 1;
		wavetime = wavetime - 1;
		//******************************************************Spawns Objects based on timer; assuming 60fps so 60 = spawn every 1 second [JC]

		if (spawntimercoin < 1) 
		{
			var randomNum = Random.Range(-1, 1f); 
			spawnpositioncoin = spawnpositioncoin + randomNum; //*******************Spawns a coin close to the last one [JC]
				if (spawnpositioncoin > 7)
				{
					spawnpositioncoin = 6;
				}
				if (spawnpositioncoin < 1)
				{
					spawnpositioncoin = 2;
				}
			currentPos.y = spawnpositioncoin;
			transform.position = currentPos;

            if (GameMaster.playerIsAlive)
            {
                Instantiate(coin, currentPos, currentRot);
            }
			
			//Instantiate(blueJelly, currentPos, currentRot);
			spawntimercoin = spawntimercoinwave;
		}

		if (spawntimercrystalgreen < 1) 
		{
			var randomNum = Random.Range(-3, 3f); 
			spawnpositioncrystalgreen = 3;
			spawnpositioncrystalgreen = spawnpositioncrystalgreen + randomNum; //*******************Spawns a coin close to the last one [JC]

			currentPos.y = spawnpositioncrystalgreen;
			transform.position = currentPos;
			
			if (GameMaster.playerIsAlive)
			{
				Instantiate(crystalgreen, currentPos, currentRot);
			}
			
			//Instantiate(blueJelly, currentPos, currentRot);
			spawntimercrystalgreen = spawntimercrystalgreenwave;
		}

		if (spawntimerfloor < 1) 
		{
			currentPos.y = -1;
			currentPos.x = 10;
			transform.position = currentPos;
			

			Instantiate(floor, currentPos, currentRot);
			
			//Instantiate(blueJelly, currentPos, currentRot);
			spawntimerfloor = spawntimerfloorwave;
		}

		if (spawntimertopcoral < 1)                             //*******************Spawns Coral [JC]
		{
			var randomNum = Random.Range(-0.5f, 0.5f); 
			currentPos.y = 8 + randomNum;
			transform.position = currentPos;
			Instantiate(topcoral, currentPos, currentRot);
			//Instantiate(blueJelly, currentPos, currentRot);
			spawntimertopcoral = spawntimertopcoralwave;
		}

		if (spawntimerjellyswarm < 1)                             //*******************Spawns Jellyswarm [JC]
		{
			var randomNum = Random.Range(2, 5f);
			spawnpositionjellyswarm = randomNum;
			currentPos.y = spawnpositionjellyswarm;
			transform.position = currentPos;
			Instantiate(jellyswarm, currentPos, currentRot);
			//Instantiate(blueJelly, currentPos, currentRot);
			spawntimerjellyswarm = spawntimerjellyswarmwave;
		}

		if (spawntimerbluejelly < 1)                             //*******************Spawns Jellies [JC]
		{
			var randomNum = Random.Range(0, 7f);
			spawnpositionbluejelly = randomNum;
			currentPos.y = spawnpositionbluejelly;
			transform.position = currentPos;
			Instantiate(bluejelly, currentPos, currentRot);
			//Instantiate(blueJelly, currentPos, currentRot);
			spawntimerbluejelly = spawntimerbluejellywave;
		}

		if (spawntimerredjelly < 1) 
		{
			var randomNum = Random.Range(0, 7f);
			spawnpositionredjelly = randomNum;
			currentPos.y = spawnpositionredjelly;
			transform.position = currentPos;
			Instantiate(redjelly, currentPos, currentRot);
			//Instantiate(blueJelly, currentPos, currentRot);
			spawntimerredjelly = spawntimerredjellywave;
		}

		if (spawntimergreenjelly < 1) 
		{
			var randomNum = Random.Range(0, 7f);
			spawnpositiongreenjelly = randomNum;
			currentPos.y = spawnpositiongreenjelly;
			transform.position = currentPos;
			Instantiate(greenjelly, currentPos, currentRot);
			//Instantiate(blueJelly, currentPos, currentRot);
			spawntimergreenjelly = spawntimergreenjellywave;
		}

		if (spawntimerpurplejelly < 1) 
		{
			var randomNum = Random.Range(0, 7f);
			spawnpositionpurplejelly = randomNum;
			currentPos.y = spawnpositionpurplejelly;
			transform.position = currentPos;
			Instantiate(purplejelly, currentPos, currentRot);
			//Instantiate(blueJelly, currentPos, currentRot);
			spawntimerpurplejelly = spawntimerpurplejellywave;
		}

		if (spawntimerblackjelly < 1) 
		{
			var randomNum = Random.Range(0, 7f);
			spawnpositionblackjelly = randomNum;
			currentPos.y = spawnpositionblackjelly;
			transform.position = currentPos;
			Instantiate(blackjelly, currentPos, currentRot);
			//Instantiate(blueJelly, currentPos, currentRot);
			spawntimerblackjelly = spawntimerblackjellywave;
		}

		if (wavetime < 1)                                     //************Sets new wave spawnrates
		{
			var randomNum = Random.Range(15, 120);
			spawntimercoinwave = randomNum;
			randomNum = Random.Range(200, 300);
			spawntimerbluejellywave = randomNum;
			randomNum = Random.Range(300, 600);
			spawntimerredjellywave = randomNum;
			randomNum = Random.Range(600, 800);
			spawntimergreenjellywave = randomNum;
			randomNum = Random.Range(800, 1000);
			spawntimerpurplejellywave = randomNum;
			randomNum = Random.Range(1000, 1200);
			spawntimerblackjellywave = randomNum;
			wavetime = wavelength;
		}

        //spawnBounce();
        //spawnCoin();
        var randomTimer = Random.Range(0f, 2f);
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
        var randomNum = Random.Range(0, 5);
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
            //Instantiate(coin, currentPos, currentRot);
            //Instantiate(blueJelly, currentPos, currentRot);
            Debug.Log("Timer Loop Reset" + "timer was " + randomTimer);
        }
    }

}

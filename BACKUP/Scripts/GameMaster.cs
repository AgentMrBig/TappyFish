using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class GameMaster : MonoBehaviour
{
    // Timers
    public static float timeCounter = 0;
    public static bool timerBool = false;
    public static int timeLoop = 0;
    // timeRemaining is passed as arg in AltTimer()
    //public static float timeRemaining = 5f;

    // Audio
    public static float Volume = 1f;

    // Data holders such as player pos and rot
    public static Vector3 lastPlayerPos;
    public static Quaternion lastPlayerRot;
    public static Quaternion initialPlayerRot;
    public static Quaternion lastCamRot;

    // --- UI START --- 

    // Debug Switch
    public bool displayDebugInfo = true;

    // Score 
    public UnityEngine.UI.Text score;
    public static int currentScore = 0;

    // Player status, set at runtime in start() method
    public UnityEngine.UI.Text playerPosition;
    public UnityEngine.UI.Text playerRotation;
    public UnityEngine.UI.Text playerStatus;
    public UnityEngine.UI.Text DiePanelScore;
	//public UnityEngine.UI.Text frames;
    public static bool playerIsAlive = true;
    public string playerState = "";
    public string playerPos = "";
    public string playerRot = "";
	//public string frame = "";

    public static string playerName;
    public static string playerScore;


    // Death messages objects
    public GameObject dieMessage;
    public bool deathMsgExists = false;

    // Set at runtime in start() method. 
    GameObject debugInfo;
    GameObject death;
    GameObject deadEye;
    // --- UI END --- 

    void Awake()
    {
        currentScore = 0;
    }

    void Start()
    {
        // Size Debug Text
        score.fontSize = 16;
        playerStatus.fontSize = 16;
        playerPosition.fontSize = 16;
        playerRotation.fontSize = 16;
		//frames.fontSize = 16;

        // Assign debug items and death panel
        debugInfo = GameObject.Find("DebugInfo");
        death = GameObject.Find("Death");
        deadEye = GameObject.Find("FishEyeDead");
        death.SetActive(false);
        deadEye.SetActive(false);

        // Assign initial player rot value
        initialPlayerRot = GameObject.Find("Player").transform.rotation;



    }
     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        Timer();

        if (playerIsAlive)
        {
            playerState = "Alive";
            
            lastPlayerPos = GameObject.Find("Player").transform.position;
            lastPlayerRot = GameObject.Find("Player").transform.rotation;
           
            
            lastCamRot = GameObject.Find("Main Camera").transform.rotation;
        }else if (!playerIsAlive)
        {

            GiveDeadMessage();
        }

        // If debug is true
        if (displayDebugInfo)
        {
            playerPos = "Player Pos: " + lastPlayerPos.x + ", " + lastPlayerPos.y + ", " + lastPlayerPos.z;
            playerRot = "Player Rot: " + lastPlayerRot.x + ", " + lastPlayerRot.y + ", " + lastPlayerRot.z;
            // If canvas text object set for playerPosition
            if (playerPosition)
            {
                playerPosition.text = playerPos;
            }
            if (playerRotation)
            {
                playerRotation.text = playerRot;
            }

        }

        if (playerStatus)
        {
            playerStatus.text = "Player is " + playerState;
        }
        if (score)
        {
            score.text = "Score: " + currentScore;
			//frames.text = (1.0f / Time.smoothDeltaTime);        
			
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (debugInfo)
            {
                debugInfo.SetActive(false);
            }
            else
                debugInfo.SetActive(true);


        }
        
    }

    public void GiveDeadMessage()
    {
        DiePanelScore.text = "Score: " + currentScore;
        //Debug.Log("DEAD");
        // Adjust level music
        GameObject.FindGameObjectWithTag("GameMaster").GetComponent<AudioSource>().volume = Volume - 0.8f;

        // Dead eye
        deadEye.SetActive(true);

        playerState = "Dead";

        if (!deathMsgExists)
        {
            Instantiate(dieMessage, lastPlayerPos, lastCamRot);
        }

        deathMsgExists = true;

        death.SetActive(true);
    }

    public static void Timer()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter > 1)
        {
            timeCounter = 0;
            timerBool = true;
            //Debug.Log("every second");
        }
    }

    
    


}

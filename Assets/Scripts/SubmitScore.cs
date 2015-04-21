using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubmitScore : MonoBehaviour {

    public UnityEngine.UI.InputField name;

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
        if (name.text != "")
        {
            GameMaster.playerName = name.text;
            GameMaster.playerScore = GameMaster.currentScore.ToString();
            HighscoreSaver.postScore(GameMaster.playerName, GameMaster.playerScore, this);
            Debug.Log("Submit Score button was pressed");
        }
        else if (name.text == "")
        {
            name.text = "Need Name";
        }
        else if (name.text == "Need Name")
        {
            name.text = "PUT NAME";
        }
        
    }

    public void OnHighscoreLoaded(List<HighscoreSaver.Highscore> highscores)
    {
        Debug.Log("Updating highscores!");
        Debug.Log("--------------------");
        string text = "";
        foreach (HighscoreSaver.Highscore hs in highscores)
        {
            text += hs.name + "\t\t" + hs.score + "\n";
            Debug.Log(text);
        }
        //GetComponent<GUIText>().text = text;
    }
    public void OnHighscorePosted()
    {
        Debug.Log("Post successful, updating scores!");
        HighscoreSaver.loadScores(this);

      
    }

    void LoadScene()
    {
        loadLock = true;
        GameMaster.playerIsAlive = true;
        Application.LoadLevel(scene);
    }
}

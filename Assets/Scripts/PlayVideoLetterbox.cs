////////////////////////////////////////////////////////////////////////////
//                                                   41 Post                                       		//
// Created by DimasTheDriver in 19/Apr/2011                                      		//
// Part of 'Unity: How to use a GUI Texture to play fullscreen videos' post.   //
// Available at:      http://www.41post.com/?p=3687                             		//
///////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUITexture))]
[RequireComponent (typeof (AudioSource))]
[RequireComponent(typeof(Fading))]

public class PlayVideoLetterbox : MonoBehaviour 
{
	//the GUI texture
	private GUITexture videoGUItex;
	//the Movie texture
	private MovieTexture mTex;
	//the AudioSource
	private AudioSource movieAS;
	//the movie name inside the resources folder
	public string movieName;
	public  string lvlLoad;
	private bool skip = false;
	public float vidDuration;
	
	void Awake()
	{
		//get the attached GUITexture
		videoGUItex = this.GetComponent<GUITexture> ();
		//get the attached AudioSource
		movieAS = this.GetComponent<AudioSource> ();
		//load the movie texture from the resources folder
		mTex = (MovieTexture)Resources.Load (movieName);
		//set the AudioSource clip to be the same as the movie texture audio clip
		movieAS.clip = mTex.audioClip;
		//letterbox
		float newHeight = -(Screen.height - (Screen.width / (mTex.width / (float)mTex.height)));
		float yOffset = (-Screen.height - newHeight) / 2;
		videoGUItex.pixelInset = new Rect (Screen.width / 2, yOffset, 0, newHeight);
	
	}

	void Start()
	{

		this.GetComponent<Fading> ().BeginFade (-1);

		//set the videoGUItex.texture to be the same as mTex
		videoGUItex.texture = mTex;
		//Plays the movie
		mTex.Play();
		//plays the audio from the movie
		movieAS.Play(); 
		StartCoroutine (LoadNextScene (vidDuration));
	}
	


	IEnumerator LoadNextScene(float waitTime)
	{	
		if(!skip)
		   {
		yield return new WaitForSeconds (waitTime);
		Application.LoadLevel(lvlLoad);
		   }
		 else 
		 {
			yield break;
		 }
	}


	void Update()
	{
		if(Input.GetKeyDown ("space"))
		{	
			skip = true;
			StartCoroutine (SkipCutScene ());
		}
	}

	//controls all the changes in the alpha of the video

	IEnumerator SkipCutScene()
	{
		//fade out game and load a new level

		float fadeTime = this.GetComponent<Fading> ().BeginFade (1);
		movieAS.volume = Mathf.Lerp (0, 1, fadeTime);
		yield return new WaitForSeconds (fadeTime* 1.8f);
		mTex.Stop ();
		Application.LoadLevel (lvlLoad);
	}
}

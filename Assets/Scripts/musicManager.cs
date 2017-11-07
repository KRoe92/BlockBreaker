using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour {


	public AudioClip mainMusic;
	public GameObject gameMusic;
	bool music = true;

	// Manages music conrtol in game
	void Start () {

		gameObject.GetComponent<AudioSource> ().PlayOneShot (mainMusic);
		
	}

	public void toggleMusic()
	{
		music = !music;
		gameMusic.SetActive (!gameMusic.activeSelf);
	}

	public void playMainMusic()
	{
		if (music)
			gameObject.GetComponent<AudioSource> ().PlayOneShot (mainMusic);
	}
}

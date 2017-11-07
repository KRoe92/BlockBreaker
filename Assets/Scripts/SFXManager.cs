using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

	public AudioClip buttonPop;
	public AudioClip wallKnock;
	public AudioClip blockbreak;
	public AudioClip blockTap;
	public AudioClip paddleKnock;

	public AudioClip coinDing;
	public AudioClip powerBop;
	public AudioClip gemTap;
	public AudioClip gemBlast;
	bool mute;

	//A collection of audio triggers determined by which enum is passed into the method
	public void playSound(Helper.soundEffect sound)
	{
		if (!mute) {
			
			switch (sound) 
			{
				case Helper.soundEffect.blockbreak:
					gameObject.GetComponent<AudioSource> ().pitch = 0.72f;
					gameObject.GetComponent<AudioSource> ().volume = 0.12f;
					gameObject.GetComponent<AudioSource> ().PlayOneShot (blockbreak);
					break;

				case Helper.soundEffect.blockTap:
					gameObject.GetComponent<AudioSource> ().pitch = 1f;
					gameObject.GetComponent<AudioSource> ().volume = 0.14f;
					gameObject.GetComponent<AudioSource> ().PlayOneShot (blockTap);
					break;

				case Helper.soundEffect.ButtonPop:
					gameObject.GetComponent<AudioSource> ().pitch = 1;
					gameObject.GetComponent<AudioSource> ().volume = 0.45f;
					gameObject.GetComponent<AudioSource> ().PlayOneShot (buttonPop);
					break;

				case Helper.soundEffect.coinDing:
					gameObject.GetComponent<AudioSource> ().pitch = 0.72f;
					gameObject.GetComponent<AudioSource> ().volume = 0.2f;
					gameObject.GetComponent<AudioSource> ().PlayOneShot (coinDing);
					break;

				case Helper.soundEffect.gemBlast:
					gameObject.GetComponent<AudioSource> ().pitch = 1f;
					gameObject.GetComponent<AudioSource> ().volume = 0.4f;
					gameObject.GetComponent<AudioSource> ().PlayOneShot (gemBlast);
					break;

				case Helper.soundEffect.gemTap:
					gameObject.GetComponent<AudioSource> ().pitch = 1f;
					gameObject.GetComponent<AudioSource> ().volume = 0.4f;
					gameObject.GetComponent<AudioSource> ().PlayOneShot (gemTap);
					break;

				case Helper.soundEffect.paddleKnock:
					gameObject.GetComponent<AudioSource> ().pitch = 0.72f;
					gameObject.GetComponent<AudioSource> ().volume = 0.12f;
					gameObject.GetComponent<AudioSource> ().PlayOneShot (paddleKnock);
					break;

				case Helper.soundEffect.powerBop:
					gameObject.GetComponent<AudioSource> ().pitch = 1;
					gameObject.GetComponent<AudioSource> ().volume = 0.45f;
					gameObject.GetComponent<AudioSource> ().PlayOneShot (powerBop);
					break;

				case Helper.soundEffect.wallKnock:
					gameObject.GetComponent<AudioSource> ().pitch = 0.72f;
					gameObject.GetComponent<AudioSource> ().volume = 0.12f;
					gameObject.GetComponent<AudioSource> ().PlayOneShot (wallKnock);
					break;
			}

		}
	}

	public void popButton()
	{
		playSound (Helper.soundEffect.ButtonPop);
	}

	public void toggleMute()
	{
		mute = !mute;
	}
}

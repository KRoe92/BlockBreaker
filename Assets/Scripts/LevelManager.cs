using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	//Deals with level setup and clean up and manages level index

	public GameObject paddle;
	public GameObject header;
	public GameObject FooterMessage;
	public GameObject FooterNum;
	public GameObject FooterLives;
	public GameObject complete;
	public GameObject completeButton;
	public GameObject completeMessage;
	public GameObject mainMusic;

	int currentLevel = 1;

	public void setLevel(int newLevel)
	{
		currentLevel = newLevel;
	}

	public int getLevel()
	{
		return currentLevel;
	}

	public void createLevel()
	{
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).gameObject.SetActive(false);
		}
			
		transform.GetChild (currentLevel - 1).gameObject.SetActive(true);

		paddle.SetActive (true);
		header.SetActive (true);
		gameObject.GetComponent<GameManager>().newGame ();
		FooterNum.SetActive (true);
		FooterMessage.SetActive (true);
		FooterLives.SetActive (true);
		FooterNum.GetComponent<Text> ().text = "" + currentLevel;
		mainMusic.GetComponent<AudioSource> ().Stop ();

	}

	public void destroyLevel()
	{
		Transform current = transform.GetChild (currentLevel - 1);
		for (int i = 0; i < current.childCount; i++) {
			Transform row = current.GetChild (i);
			for (int j = 0; j < row.childCount; j++) {
				row.GetChild (j).gameObject.SetActive (true);
			}
		}
		destroyBalls ();
		destroyItems ();
		current.gameObject.SetActive(false);
		paddle.SetActive (false);
		FooterNum.SetActive (false);
		FooterMessage.SetActive (false);
		FooterLives.SetActive (false);
	}

	public void destroyBalls()
	{
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		for (int i = 0; i < balls.Length; i++) {
			Destroy (balls [i]);
		}
	}

	public void destroyItems()
	{
		GameObject[] items = GameObject.FindGameObjectsWithTag ("Item");
		for (int i = 0; i < items.Length; i++) {
			Destroy (items [i]);
		}
	}

	public void nextLevel()
	{
		currentLevel++;
		createLevel ();
	}

	public void FinishedLevel()
	{
		complete.SetActive (true);
		if (currentLevel == 15) {
			completeButton.SetActive (false);
			completeMessage.SetActive (true);
		}
		else {
			completeButton.SetActive (true);
			completeMessage.SetActive (false);
		}
	}
}

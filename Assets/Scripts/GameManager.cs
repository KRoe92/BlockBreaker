using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//Manages in game control, money management, success tracking, pausing game
	public GameObject remaining;
	public GameObject score;
	public GameObject endScore;
	public GameObject pauseOverlay;
	public GameObject failOverlay;
	public GameObject livesText;

	public GameObject ballPrefab;
	public GameObject paddle;
	public bool isPaused;

	Vector3 originalScale;

	int totalBricks;
	int totalScore;
	int totalLives;

	bool scalingUp;
	bool scalingDown;
	float t = 0.0f;

	// Use this for initialization
	void Start () {

		originalScale = paddle.transform.localScale;
		gameObject.GetComponent<spawnManager>().spawnBall(new Vector3(0, -1.5f, 0));
	}
	
	// Update is called once per frame
	void Update () {

		scaleLerp ();
	}

	void setBall()
	{
		GameObject ball = Instantiate (ballPrefab);
		ball.transform.SetParent (paddle.transform);
		ball.transform.localPosition = new Vector3(0,0.4f,0);
		ball.GetComponent<Rigidbody2D> ().isKinematic = true;
	}

	int checkForBalls()
	{
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		return balls.Length;
	}

	public void respawnBall()
	{
		if (checkForBalls () == 1 && totalLives > 1) {
			setBall ();
			totalLives--;
			livesText.GetComponent<Text> ().text = "X " + totalLives;
		} 
		else if(checkForBalls () == 1 && totalLives == 1){
			gameObject.GetComponent<LevelManager> ().destroyLevel();
			failOverlay.SetActive (true);
		}
			
	}

	void resetMoney()
	{
		totalScore = 0;
		score.GetComponent<Text> ().text = "" + totalScore;
		endScore.GetComponent<Text> ().text = "" + totalScore;
	}
		
	void setBrickCount()
	{
		Transform level = transform.GetChild (gameObject.GetComponent<LevelManager>().getLevel() - 1);
		int count = 0;
		for (int i = 0; i < level.childCount; i++) {
			Transform row = level.GetChild (i);
			for (int j = 0; j < row.childCount; j++) {
				if (row.GetChild (j).gameObject.activeSelf)
					count++;
			}
		}
		totalBricks = count;
		remaining.GetComponent<Text> ().text = "" + totalBricks;
	}


	public void minusBrick()
	{
		totalBricks--;
		remaining.GetComponent<Text> ().text = "" + totalBricks;
		if (totalBricks == 0) {
			gameObject.GetComponent<LevelManager> ().destroyLevel();
			gameObject.GetComponent<LevelManager> ().FinishedLevel ();
		}
	}

	public void addScore(int morePoints)
	{
		totalScore += morePoints;
		score.GetComponent<Text> ().text = "" + totalScore;
		endScore.GetComponent<Text> ().text = "" + totalScore;
	}

	public void newGame()
	{
		paddle.transform.localScale = originalScale;
		resetMoney ();
		setBrickCount ();
		setBall ();
		totalLives = 3;
		livesText.GetComponent<Text> ().text = "X " + totalLives;
	}

	public void pauseGame()
	{
		setScale (true);
		isPaused = true;
	}

	public void resumeGame()
	{
		Time.timeScale = 1;
		setScale (false);
		isPaused = false;
	}

	void setScale(bool val)
	{
		scalingUp = val;
		scalingDown = !scalingUp;
		t = 0;
	}

	void scaleLerp()
	{
		float sizeVal = 0;
		if(scalingUp)
		{
			sizeVal = Mathf.Lerp(0, 1, t);
			t += Time.deltaTime * 2;
			pauseOverlay.GetComponent<RectTransform>().localScale = sizeVal * Vector3.one;
				if(sizeVal == 1)
					Time.timeScale = 0;
		}
		else if (scalingDown)
		{
			sizeVal = Mathf.Lerp(1, 0, t);
			t += Time.deltaTime * 2;
			pauseOverlay.GetComponent<RectTransform>().localScale = sizeVal * Vector3.one;
		}
	}

	public void closeGame()
	{
		Application.Quit ();
	}
}

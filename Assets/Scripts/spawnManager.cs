using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnManager : MonoBehaviour {

	public GameObject ballPrefab;
	public GameObject powerUpPrefab;
	public GameObject coinPrefab;
	public GameObject pointDisplay;
	public Transform canvas;
	public int odds;
	public GameObject explosion;


	//Spawns the different collectables for the player, such as coins, extra balls and paddle upgrades
	public void breakBrick(Vector3 pos)
	{
		display (pos, 50);
		int val = (int)Random.Range (0, odds);

		switch (val) {
		case 1:
		case 2:
			Instantiate (ballPrefab, pos, Quaternion.identity);
			break;
		case 3:
			Instantiate (powerUpPrefab, pos, Quaternion.identity);
			break;
		case 4:
		case 5:
		case 6:
			Instantiate (coinPrefab, pos, Quaternion.identity);
			break;
		}
	}

	public void gemBreak(Vector3 pos, Color col)
	{
		display (pos, 500);
		GameObject exp = Instantiate (explosion, pos, Quaternion.identity);
		exp.GetComponent<SpriteRenderer> ().color = col;
		GameObject.FindGameObjectWithTag("Sound").GetComponent<SFXManager> ().playSound (Helper.soundEffect.gemBlast);
		Instantiate (coinPrefab, pos, Quaternion.identity);
	}


	public void spawnBall(Vector3 pos)
	{
		GameObject.Instantiate (ballPrefab, pos, Quaternion.identity);
	}

	public void display(Vector3 pos, int points)
	{
		GameObject score = Instantiate(pointDisplay, pos, Quaternion.identity, canvas);
		score.GetComponent<Text> ().text = "" + points;
		gameObject.GetComponent<GameManager> ().addScore (points);
	}
}

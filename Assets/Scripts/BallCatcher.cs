using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCatcher : MonoBehaviour {

	//Checks if ball has left board
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Ball") {
			Destroy (coll.gameObject);
			GameObject.FindWithTag ("Spawn").GetComponent<GameManager> ().respawnBall ();
		}

	}

	public void setTrigger(bool setting)
	{
		gameObject.GetComponent<BoxCollider2D> ().isTrigger = setting;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour {

	public enum pickUp {Coin, Grow};
	public pickUp pickUpType;

	//The effects of different collectables hat are dropped in the game
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Paddle") {

			switch(pickUpType)
			{
				case pickUp.Coin:
				GameObject.FindWithTag ("Spawn").GetComponent<spawnManager> ().display (transform.position, 200);
				GameObject.FindWithTag ("Sound").GetComponent<SFXManager> ().playSound (Helper.soundEffect.coinDing);
				break;

			case pickUp.Grow:
				Transform ball = coll.transform.parent.GetChild (coll.transform.parent.childCount - 1);
				if (ball.tag == "Ball")
					ball.parent = null;
				
				coll.gameObject.transform.parent.localScale += new Vector3 (0.1f, 0, 0);
				GameObject.FindWithTag ("Sound").GetComponent<SFXManager> ().playSound (Helper.soundEffect.powerBop);

				if (ball.tag == "Ball")
					ball.parent = coll.transform.parent;
				break;
			}
			gameObject.SetActive (false);
		}
	}
}

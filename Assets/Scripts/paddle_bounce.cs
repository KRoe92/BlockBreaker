using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_bounce : MonoBehaviour {

	public float extraMomentum;

	//Adds left and right momentum to ball depending on where the ball strkes the paddle
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ball") {
			coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (extraMomentum, 0));
		}
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Ball") {
			GameObject.FindWithTag ("Sound").GetComponent<SFXManager> ().playSound (Helper.soundEffect.paddleKnock);
		}

	}
}

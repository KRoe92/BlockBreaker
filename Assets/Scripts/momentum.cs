using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class momentum : MonoBehaviour {

	public Vector2 startingForce;

	// Controls ball momentum, prevents ball from going too fast, or adds extra Y axis velocity if ball is only moving horizontally
	void Start () {

		gameObject.GetComponent<Rigidbody2D> ().AddForce (startingForce);
		
	}
	

	void Update () {

		Vector2 dir = gameObject.GetComponent<Rigidbody2D> ().velocity;
		if (!GameObject.FindGameObjectWithTag ("Spawn").GetComponent<GameManager> ().isPaused) {
			if (dir.magnitude > 5)
				gameObject.GetComponent<Rigidbody2D> ().AddForce (-50 * dir.normalized);
			else if (dir.magnitude < 4.5f)
				gameObject.GetComponent<Rigidbody2D> ().AddForce (50 * dir.normalized);
		}

		float angle = Mathf.Atan2 (dir.y, dir.x) * 180 / Mathf.PI;
		if (angle < 0)
			angle += 360;

		if (angle < 10 || (angle < 180 && angle > 170))
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, 30));
		if (angle > 350 || (angle > 180 && angle < 190))
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, -30));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paddle_movement : MonoBehaviour {

	public int speed;
	public GameObject stats;

	//Paddle Control: if not using touch controls A moves left, D moves right, M shoots ball
	void Update () {

		if(Input.GetKey(KeyCode.A))
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-1,0) * speed);
		if(Input.GetKey(KeyCode.D))
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(1,0) * speed);

		if (Input.GetKey (KeyCode.M)) {

			for (int i = 0; i < transform.childCount; i++) {
				Transform ball = transform.GetChild (i);
				if (ball.tag == "Ball") {
					ball.GetComponent<Rigidbody2D> ().isKinematic = false;
					ball.GetComponent<Rigidbody2D> ().AddForce (new Vector2(40, 100));
					ball.parent = null;
				}
			}
		}

		if (Input.touchCount == 1) {
			Vector2 touchPos = Input.touches [0].position/Screen.width;
			float relativeTouchX = (touchPos.x - 0.5f) * 5;
			float diff = relativeTouchX - transform.position.x;
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(2,0) * (speed * diff));

		}

		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			for (int i = 0; i < transform.childCount; i++) {
				Transform ball = transform.GetChild (i);
				if (ball.tag == "Ball") {
					ball.GetComponent<Rigidbody2D> ().isKinematic = false;
					ball.GetComponent<Rigidbody2D> ().AddForce (new Vector2(40, 100));
					ball.parent = null;
				}
			}
		}
	}
}

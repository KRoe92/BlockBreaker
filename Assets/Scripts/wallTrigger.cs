using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTrigger : MonoBehaviour {

	//A trigger for adding sound to wall collisions
	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Ball")
			GameObject.FindWithTag ("Sound").GetComponent<SFXManager> ().playSound (Helper.soundEffect.wallKnock);
	}
}

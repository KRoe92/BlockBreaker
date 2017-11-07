using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour {

	public Helper.gemColour blockColor;

	//Block DESTRUCTION!
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.GetComponent<colorManager> ().getColor () == blockColor || blockColor == Helper.gemColour.white) {
			gameObject.SetActive (false);
			GameObject.FindWithTag ("Spawn").GetComponent<spawnManager> ().breakBrick (transform.position);
			GameObject.FindWithTag ("Spawn").GetComponent<GameManager> ().minusBrick ();
			GameObject.FindWithTag ("Sound").GetComponent<SFXManager> ().playSound (Helper.soundEffect.blockbreak);
		} 
		else {
			GameObject.FindWithTag ("Sound").GetComponent<SFXManager> ().playSound (Helper.soundEffect.blockTap);
		}
	}
}

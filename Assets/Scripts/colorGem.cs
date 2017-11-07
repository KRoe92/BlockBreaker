using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorGem : MonoBehaviour {

	public Helper.gemColour myCol;
	public GameObject level;

	//Checks how many colored blocks are left, if zero, then gem explodes (Should be in seperate trigger instead of Update *Fix in future)
	void Update () {

		int counter = 0;
		for (int i = 0; i < level.transform.childCount; i++) {
			if(level.transform.GetChild (i).tag != "Gem")
			{
				Transform row = level.transform.GetChild (i);
				for (int j = 0; j < row.childCount; j++) {
					if (row.GetChild (j).GetComponent<BlockBehavior> ().blockColor == myCol && row.GetChild (j).gameObject.activeSelf)
						counter++;
				}
			}
		}
			
		if (counter == 0) {
			gameObject.SetActive (false);
			GameObject.FindWithTag ("Spawn").GetComponent<spawnManager> ().gemBreak (transform.position, gameObject.GetComponent<SpriteRenderer>().color);
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		coll.gameObject.GetComponent<colorManager> ().setColor(myCol);
	}
}

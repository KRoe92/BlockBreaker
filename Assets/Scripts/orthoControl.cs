using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orthoControl : MonoBehaviour {

	
	//Sets size of ortho to fit screen size
	void Update () {
		Camera.main.orthographicSize = ((float)Screen.height / (float)Screen.width) * 3;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorManager : MonoBehaviour {

	Helper.gemColour ballColor;

	//Changes ball color when colliding with colored gems
	public void setColor(Helper.gemColour myColor)
	{
		if(myColor != ballColor)
			GameObject.FindWithTag ("Sound").GetComponent<SFXManager> ().playSound (Helper.soundEffect.gemTap);
		else
			GameObject.FindWithTag ("Sound").GetComponent<SFXManager> ().playSound (Helper.soundEffect.wallKnock);

		if (myColor == Helper.gemColour.red)
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (255.0f/255.0f, 84/255.0f, 84/255.0f);
		else if (myColor == Helper.gemColour.blue)
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (41.0f/255.0f, 255/255.0f, 255/255.0f);
		else if (myColor == Helper.gemColour.green)
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (199.0f/255.0f, 255/255.0f, 41/255.0f);
		ballColor = myColor;
	}

	public Helper.gemColour getColor()
	{
		return ballColor;
	}
		
}

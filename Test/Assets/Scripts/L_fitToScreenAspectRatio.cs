using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_fitToScreenAspectRatio : MonoBehaviour {


	
	
	// Richard, either combine this line with your UI elements in a late update method or attach this script to every UI element
	void LateUpdate () {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
    } // this script turned out to be redundant as we could just align the ui to the top left pivot point for a quick fix however for other devices like tablets and smaller screens this script would be much more useful as a screen rescaler
}

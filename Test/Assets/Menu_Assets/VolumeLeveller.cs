using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeLeveller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<AudioSource>().volume = L_MenuUI.globalVolumeLevel;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_destroyAfter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 60);
	}
	
	// Update is called once per frame
	
}

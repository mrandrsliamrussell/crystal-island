using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class L_EnvironmentSound : MonoBehaviour {
    public AudioSource audiosource;
    public AudioClip audioclip, audioclip1;
	// Use this for initialization
	void Start () {
        StartCoroutine(playsound());
	}
	
	IEnumerator playsound()
    {
        yield return new WaitForSeconds(Random.Range(180, 360));
        if (Mathf.CeilToInt(Time.time) % 2 == 0)
        {
            audiosource.PlayOneShot(audioclip);
        }
        else
        {

            audiosource.PlayOneShot(audioclip1);
        }
        yield return new WaitForSeconds(Random.Range(180, 360));
        StartCoroutine(playsound());
    }
    //this script uses a recursive co routine to play a random environment sound after a random interval using time as a dice to decide, this could be used in any game as this script has no other specific outside script dependancies.
}

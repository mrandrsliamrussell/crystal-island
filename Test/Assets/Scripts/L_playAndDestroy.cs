using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class L_playAndDestroy : MonoBehaviour {
    public AudioSource thisAudioSource;
    public AudioClip thisAudioClip;
	// Use this for initialization
void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            thisAudioSource.PlayOneShot(thisAudioClip);
            Debug.Log("audio one off playing");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}// this script is designed for a one time sound use when a player object collides with it, in this game it is used for fanfares when you discover a ruin or the main temple.

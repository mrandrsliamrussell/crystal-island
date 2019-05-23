using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class L_playsound : MonoBehaviour {
    public List<AudioClip> audioList;
    public AudioSource audioSource;
    public int numberOfSounds;
	// Use this for initialization
	void Start () {
      audioSource = this.gameObject.AddComponent<AudioSource>();
	}
	
	public void playSound(int soundIndex)
        
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.volume = L_MenuUI.globalVolumeLevel;
            audioSource.PlayOneShot(audioList[soundIndex]);
            
        }
        
    }
} //this script is designed to be tacked onto an existing gameobject to give it acess to a sound library, the script already on the gameobject would just need to call the play sound method and then the index of the sound in the list to play it, this is designed for reusability and ease of use by a programmer as a one size fits all for adding sound to any script rather that squeezing it into an existing script.

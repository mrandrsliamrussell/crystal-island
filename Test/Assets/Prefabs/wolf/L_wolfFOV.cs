using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_wolfFOV : MonoBehaviour {

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameObject.GetComponentInParent<L_JaguarV2>().canSee = true;
            Debug.Log("can see player");
        }
       
      
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameObject.GetComponentInParent<L_JaguarV2>().canSee = false;
        }
    }// this script passes information to the parent to check if the sub collider has collided with the player
}

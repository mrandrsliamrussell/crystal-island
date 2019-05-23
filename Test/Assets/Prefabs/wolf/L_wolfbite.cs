using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_wolfbite : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameObject.GetComponentInParent<L_JaguarV2>().hasAttacked = true;
            Debug.Log("can see player");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameObject.GetComponentInParent<L_JaguarV2>().hasAttacked = false;
        }
    }
}// this script passes information to the parent to check if the sub collider has collided with the player

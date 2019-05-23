using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_EatFood : MonoBehaviour {

    public Text foodStored;
    public GameObject player;

    public void EatFood()
    {
        if(R_Pickuptext.foodCollected >= 1)
        {
            R_Pickuptext.foodCollected = R_Pickuptext.foodCollected - 1;
            foodStored.text = R_Pickuptext.foodCollected.ToString();
            if (player.GetComponent<L_playerStatChange>().playerHunger >=0 && player.GetComponent<L_playerStatChange>().playerHunger <= 75)
            {
                player.GetComponent<L_playerStatChange>().playerHunger += 25;
            }
            else if (player.GetComponent<L_playerStatChange>().playerHunger >= 75)
            {
                player.GetComponent<L_playerStatChange>().playerHunger = 100;
            }
            else if (player.GetComponent<L_playerStatChange>().playerHunger <= 0)
            {
                player.GetComponent<L_playerStatChange>().playerHunger = 25;
            }
            player.GetComponent<R_Pickuptext>().ShowEatButton();


        }
        else
        {
            //Debug.Log("no food to eat");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_cookMeat : MonoBehaviour {

    public Text rawMeatCollected;
    public Text cookedMeatStorred;
    public static int cookedMeatCollected = 0;
    public GameObject player;

    void Awake()
    {
        cookedMeatCollected = 0;             //re-initialise static variables
    }

    public void CookMeat()
    {
        if (R_Pickuptext.meatCollected >= 1 && PlayerMove.atFire == true)     //check if player has meat and is by fire
        {
            R_Pickuptext.meatCollected = R_Pickuptext.meatCollected - 1;
            rawMeatCollected.text = R_Pickuptext.meatCollected.ToString();
            cookedMeatCollected = cookedMeatCollected + 1;
            cookedMeatStorred.text = cookedMeatCollected.ToString();
            player.GetComponent<R_Pickuptext>().ShowCookMeatButton();        // these are checks to see if button should be displayed
            player.GetComponent<R_Pickuptext>().ShowEatMeatButton();
            player.gameObject.GetComponent<L_playsound>().playSound(1);



        }
    }

	public void EatMeat()
    {
        if(cookedMeatCollected >= 1)
        {
            cookedMeatCollected = cookedMeatCollected - 1;
            cookedMeatStorred.text = cookedMeatCollected.ToString();
            if(player.GetComponent<L_playerStatChange>().playerHunger >= 0 && player.GetComponent<L_playerStatChange>().playerHunger <= 75)  // check if health between 0 and 75
            {
                player.GetComponent<L_playerStatChange>().playerHunger += 25;
            }
            else if(player.GetComponent<L_playerStatChange>().playerHunger >= 75)
            {
                player.GetComponent<L_playerStatChange>().playerHunger = 100;
            }
            else if (player.GetComponent<L_playerStatChange>().playerHunger <= 0)
            {
                player.GetComponent<L_playerStatChange>().playerHunger = 25;
            }
            player.GetComponent<R_Pickuptext>().ShowEatMeatButton();   // check if button should still be displayed
        }
    }
}

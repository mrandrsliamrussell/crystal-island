using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_craftFire : MonoBehaviour {

    public Text sticksStored;
    public Text rockStored;
    public GameObject fireplace, oldFire;
    public GameObject player;

	public void CraftFire()
    {
        if(CraftingManager.sticksCollected >=8 && R_Pickuptext.rockCollected >= 6 && player.GetComponent<PlayerMove>().isInWater == false && player.GetComponent<PlayerMove>().isInSea == false) // so player cannot spawn fire in water
        {
            CraftingManager.sticksCollected = CraftingManager.sticksCollected - 8;
            sticksStored.text = CraftingManager.sticksCollected.ToString();
            R_Pickuptext.rockCollected = R_Pickuptext.rockCollected - 6;
            rockStored.text = R_Pickuptext.rockCollected.ToString();
            GameObject thisFire = Instantiate(fireplace, player.transform.position + (player.transform.forward * 5), player.transform.rotation) as GameObject;
            GameObject thisFire2 = Instantiate(oldFire, player.transform.position + (player.transform.forward * 5), player.transform.rotation) as GameObject;
            Destroy(thisFire, 60);     //destroy lit fire after 60 seconds
            //Debug.Log("fireplace crafted");
            player.GetComponent<R_Pickuptext>().ShowFireButton();            // these are checks to see which buttons should be displayed in inventory
            player.GetComponent<R_Pickuptext>().ShowFlintButton();
            player.GetComponent<R_Pickuptext>().ShowRopeButton();
            player.GetComponent<R_Pickuptext>().ShowAxeButton();
            player.GetComponent<R_Pickuptext>().ShowShelterButton();
            player.GetComponent<L_playsound>().playSound(2);

        }
        else
        {
            //Debug.Log("need more materials");
        }
    }
    
}

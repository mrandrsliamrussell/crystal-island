using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_craftShelter : MonoBehaviour {

    public Text sticksStored;
    public Text ropeStored;
    public Text foliageStored;
    public GameObject shelter;
    public GameObject player;

    public void CraftShelter()
    {
        if(CraftingManager.sticksCollected >= 4 && CraftingManager.ropeCollected >= 2 && R_Pickuptext.foliageCollected >= 4 && player.GetComponent<PlayerMove>().isInWater == false && player.GetComponent<PlayerMove>().isInSea == false)  //check if player has items and not in water
        {
            CraftingManager.sticksCollected = CraftingManager.sticksCollected - 4;
            sticksStored.text = CraftingManager.sticksCollected.ToString();
            CraftingManager.ropeCollected = CraftingManager.ropeCollected - 2;
            ropeStored.text = CraftingManager.ropeCollected.ToString();
            R_Pickuptext.foliageCollected = R_Pickuptext.foliageCollected - 4;
            foliageStored.text = R_Pickuptext.foliageCollected.ToString();
            Instantiate(shelter, player.transform.position + (player.transform.forward * 5), player.transform.rotation);
            player.GetComponent<R_Pickuptext>().ShowShelterButton();   // checks if buttons should be displayed
            player.GetComponent<R_Pickuptext>().ShowAxeButton();
            player.GetComponent<L_playsound>().playSound(2);
        }
        else
        {
            //Debug.Log("materials needed");   
        }
    }
}

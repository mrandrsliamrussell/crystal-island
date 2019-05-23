using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{

    public GameObject player, emptyBush, axeHolder, claws;
    public Camera playerCam;
    public float rayLength;    //range of pick up ray
    public Text goodBerriesStorred, badBerriesStorred;
    public Text waterStored, hempStorred, ropeStorred, flintStored, sticksStored, woodStored;
    public static int ropeCollected;
    public static bool axeCrafted = false;
    public static int flintCollected = 0;
    public static int sticksCollected = 0;
    public Text rockStored;
    

    void Awake()
    {
        ropeCollected = 0;   // reset static variables to original value on reload
        axeCrafted = false;
        flintCollected = 0;
        sticksCollected = 0;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray2 = playerCam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Physics.Raycast(ray2, out hit, rayLength) && hit.transform.gameObject.tag == "goodBerries")
            {
                if (player.GetComponent<L_playerStatChange>().playerHunger <= 0)   //if player health goes under zero, set to 25 not current health + 25
                {
                    player.GetComponent<L_playerStatChange>().playerHunger = 25;
                }
                else if (player.GetComponent<L_playerStatChange>().playerHunger >= 0 && player.GetComponent<L_playerStatChange>().playerHunger <= 75)
                {
                    player.GetComponent<L_playerStatChange>().playerHunger += 25;
                }
                else if (player.GetComponent<L_playerStatChange>().playerHunger >= 75)   // limit player health to 100
                {
                    player.GetComponent<L_playerStatChange>().playerHunger = 100;
                }
                
                    Destroy(hit.transform.gameObject);
                GameObject instance = Instantiate(emptyBush, hit.transform.position, hit.transform.rotation) as GameObject;    //spawn empty bush at location
                instance.gameObject.GetComponent<R_respawnGoodBerries>().Respawn();              // start respawn function on this object instance
            }
            else if (Physics.Raycast(ray2, out hit, rayLength) && hit.transform.gameObject.tag == "badBerries")
            {
                player.GetComponent<L_playerStatChange>().playerHealth -= 20;
                Destroy(hit.transform.gameObject);
                GameObject instance = Instantiate(emptyBush, hit.transform.position, hit.transform.rotation) as GameObject;
                instance.gameObject.GetComponent<R_respawnGoodBerries>().RespawnBad();
            }
            else if (Physics.Raycast(ray2, out hit, rayLength) && hit.transform.gameObject.tag == "water")
            {
                if(player.GetComponent<L_playerStatChange>().playerThirst >=0 && player.GetComponent<L_playerStatChange>().playerThirst <= 75)
                {
                    player.GetComponent<L_playerStatChange>().playerThirst += 25;
                }
                else if (player.GetComponent<L_playerStatChange>().playerThirst >= 75)
                {
                    player.GetComponent<L_playerStatChange>().playerThirst = 100;
                }
                else if(player.GetComponent<L_playerStatChange>().playerThirst <= 0)
                {
                    player.GetComponent<L_playerStatChange>().playerThirst = 25;
                }
            }
        }
    }

    public void EatGoodBerries()
    {
        if (R_Pickuptext.goodBerriesCollected >= 1)
        {
            R_Pickuptext.goodBerriesCollected = R_Pickuptext.goodBerriesCollected - 1;
            goodBerriesStorred.text = R_Pickuptext.goodBerriesCollected.ToString();
            if(player.GetComponent<L_playerStatChange>().playerHunger >= 0 && player.GetComponent<L_playerStatChange>().playerHunger <= 75)
            {
                player.GetComponent<L_playerStatChange>().playerHunger +=25;
            }
            else if(player.GetComponent<L_playerStatChange>().playerHunger >= 75)  //check current hunger so dosent exceed 100%
            {
                player.GetComponent<L_playerStatChange>().playerHunger = 100;
            }
            else if (player.GetComponent<L_playerStatChange>().playerHunger <= 0)
            {
                player.GetComponent<L_playerStatChange>().playerHunger = 25;
            }
           
            player.GetComponent<R_Pickuptext>().ShowGoodBerryButton();     // function to check if player has berries, if none dont display eat button, if they have berries display eat button
        }
    }
    public void EatBadBerries()
    {
        if (R_Pickuptext.badBerriesCollected >= 1)
        {
            R_Pickuptext.badBerriesCollected = R_Pickuptext.badBerriesCollected - 1;
            badBerriesStorred.text = R_Pickuptext.badBerriesCollected.ToString();
            player.GetComponent<L_playerStatChange>().playerHealth -= 20;
            player.GetComponent<R_Pickuptext>().ShowBadBerryButton();
        }
    }
    public void DrinkWater()
    {
        if (R_Pickuptext.waterCollected >= 1)
        {
            R_Pickuptext.waterCollected = R_Pickuptext.waterCollected - 1;
            waterStored.text = R_Pickuptext.waterCollected.ToString();
            if(player.GetComponent<L_playerStatChange>().playerHunger >= 0 && player.GetComponent<L_playerStatChange>().playerThirst <= 75)
            {
                player.GetComponent<L_playerStatChange>().playerThirst += 25;
            }
            else if (player.GetComponent<L_playerStatChange>().playerThirst >= 75)
            {
                player.GetComponent<L_playerStatChange>().playerThirst = 100;
            }
            else if (player.GetComponent<L_playerStatChange>().playerThirst <= 0)
            {
                player.GetComponent<L_playerStatChange>().playerThirst = 25;
            }
            player.GetComponent<R_Pickuptext>().ShowDrinkButton();
        }
        else
        {
            //Debug.Log("you have no water");
        }
    }
    public void CraftRope()
    {
        if(R_Pickuptext.hempCollected >= 1)
        {
            R_Pickuptext.hempCollected = R_Pickuptext.hempCollected - 1;        //counting items
            hempStorred.text = R_Pickuptext.hempCollected.ToString();           //displaying count  
            ropeCollected++;
            ropeStorred.text = ropeCollected.ToString();
            player.GetComponent<R_Pickuptext>().ShowRopeButton();            //checks to see if craft buttons should be displayed in inventory
            player.GetComponent<R_Pickuptext>().ShowShelterButton();
            player.GetComponent<R_Pickuptext>().ShowFireButton();
            player.GetComponent<R_Pickuptext>().ShowAxeButton();
            player.GetComponent<L_playsound>().playSound(2);
        }
    }

    public void CraftAxe()
    {
        if (axeCrafted == false && flintCollected >= 1 && sticksCollected >= 2 && ropeCollected >= 1)
        {
            flintCollected = flintCollected - 1;
            flintStored.text = flintCollected.ToString();
            sticksCollected = sticksCollected - 2;
            sticksStored.text = sticksCollected.ToString();
            ropeCollected = ropeCollected - 1;
            ropeStorred.text = ropeCollected.ToString();
            axeCrafted = true;
            axeHolder.gameObject.SetActive(true);
            //Destroy(tutorialBV.gameObject);
            player.GetComponent<R_Pickuptext>().ShowAxeButton();
            player.GetComponent<R_Pickuptext>().ShowShelterButton();
            player.GetComponent<L_playsound>().playSound(2);

        }
        
    }
    public void CraftFlint()
    {
        if (R_Pickuptext.rockCollected >= 1)
        {
            flintCollected = flintCollected + 2;
            R_Pickuptext.rockCollected = R_Pickuptext.rockCollected - 1;
            rockStored.text = R_Pickuptext.rockCollected.ToString();
            flintStored.text = flintCollected.ToString();
            player.GetComponent<R_Pickuptext>().ShowFlintButton();
            player.GetComponent<R_Pickuptext>().ShowAxeButton();
            player.GetComponent<R_Pickuptext>().ShowShelterButton();
            player.GetComponent<L_playsound>().playSound(2);
        }
        
    }
    public void craftSticks()
    {
        if (R_Pickuptext.woodCollected >= 1 && sticksCollected <= 6)
        {
            sticksCollected = sticksCollected + 2;
            R_Pickuptext.woodCollected = R_Pickuptext.woodCollected - 1;
            woodStored.text = R_Pickuptext.woodCollected.ToString();
            sticksStored.text = sticksCollected.ToString();
            player.GetComponent<R_Pickuptext>().ShowStickButton();
            player.GetComponent<R_Pickuptext>().ShowShelterButton();
            player.GetComponent<R_Pickuptext>().ShowFireButton();
            player.GetComponent<R_Pickuptext>().ShowAxeButton();
            player.GetComponent<L_playsound>().playSound(2);
        }
        
    }
    public void DisplayClaws()
    {
        player.GetComponent<L_playsound>().playSound(6);
        StartCoroutine(Clawmarks());
    }

    IEnumerator Clawmarks()
    {
        claws.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);         //when enemy hits player display claw marks for 0.5 seconds
        claws.gameObject.SetActive(false);
    }
}
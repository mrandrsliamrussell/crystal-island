using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class R_Pickuptext : MonoBehaviour
{

    public Camera playerCam;
    public float rayLength;
    private int layerpickup = 8;
    private int water = 9;
    private int berryBush = 12;
    private int spinwheel = 13;
    public Text woodStored;
    public static int woodCollected = 0;
    public Text rockStored;
    public static int rockCollected = 0;
    public Text foliageStored;
    public static int foliageCollected = 0;
    public Text hempStored;
    public static int hempCollected = 0;
    public Text foodStored;
    public static int foodCollected = 0;
    public Text waterStored;
    public static int waterCollected = 0;
    public Text meatStorred;
    public static int meatCollected = 0;
    public Text goodBerriesStored;
    public static int goodBerriesCollected = 0;
    public Text badBerriesStored;
    public static int badBerriesCollected = 0;
    public GameObject buttonPrompt;  //press E to pick up tex
    public GameObject waterText;     //store or drink water text 
    public GameObject berryText;
    public GameObject inventoryFullText;
    public GameObject logSprite;
    public GameObject rockSprite;
    public GameObject foliageSprite;
    public GameObject hempSprite;
    public GameObject foodSprite;
    public GameObject waterSprite;
    public GameObject meatSprite;
    public GameObject cookedmeatSprite;
    public GameObject emptyBush;
    public GameObject craftManager;
    public GameObject gameController;
    public GameObject rockHolder;
    public GameObject demoComplete;
    public GameObject eatButton, craftwoodButton, craftflintButton, craftropeButton;
    public GameObject goodBerryButton, badBerryButton, craftShelterButton, craftFireButton, craftAxeButton, cookMeatButton, eatMeatButton, drinkButton;
    public GameObject turnMirrorText, sleepText;
    public GameObject player;

    void Awake()
    {
        woodCollected = 0;                 //re-initialise staic variables
        rockCollected = 0;
        foliageCollected = 0;
        hempCollected = 0;
        foodCollected = 0;
        waterCollected = 0;
        meatCollected = 0;
        goodBerriesCollected = 0;
        badBerriesCollected = 0;

    }

    void Start()
    {
        if (inventoryFullText.gameObject.activeInHierarchy)
            inventoryFullText.gameObject.SetActive(false);

        StartCoroutine(DisplayText());
    }
    IEnumerator DisplayText()
    {

        yield return new WaitForSeconds(2);

        inventoryFullText.gameObject.SetActive(false); //Display cant carry more item text for 2 seconds
       
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.layer == layerpickup)  //checking layers to display relevent screen prompt
        {
            buttonPrompt.gameObject.SetActive(true);
        }
        else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.layer == water)
        {
            waterText.gameObject.SetActive(true);
        }
        else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.layer == berryBush)
        {
            berryText.gameObject.SetActive(true);
        }
        else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.layer == 13)
        {
            turnMirrorText.gameObject.SetActive(true);
        }
        else if(Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.layer == 16)
        {
            sleepText.gameObject.SetActive(true);
        }
        else
        {
            buttonPrompt.gameObject.SetActive(false);
            waterText.gameObject.SetActive(false);
            berryText.gameObject.SetActive(false);
            turnMirrorText.gameObject.SetActive(false);
            sleepText.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "wood")   //checking objects tag to decide how to deal with
            {

                if (woodCollected <= 1)           //limits the amount player can carry
                {
                    logSprite.gameObject.SetActive(true);
                    woodCollected++;
                    GameObject.Destroy(hit.transform.gameObject);
                    woodStored.text = woodCollected.ToString();
                    player.GetComponent<L_playsound>().playSound(4);
                    ShowStickButton();    //checking if craft stick button should be shown
                }
                else
                {
                    inventoryFullText.gameObject.SetActive(true);
                    StartCoroutine(DisplayText());

                }
            }
            else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "rock")
            {
                if (rockCollected <= 5)
                {
                    rockSprite.gameObject.SetActive(true);
                    rockCollected++;
                    GameObject.Destroy(hit.transform.gameObject);
                    GameObject newRock = Instantiate(rockHolder, hit.transform.position, hit.transform.rotation) as GameObject; // hold transform reference
                    newRock.gameObject.GetComponent<R_RespawnResources>().RespawnRock(); //call respawn function
                    rockStored.text = rockCollected.ToString();
                    player.GetComponent<L_playsound>().playSound(4);
                    ShowFlintButton();
                    ShowFireButton();
                }
                else
                {
                    inventoryFullText.gameObject.SetActive(true);
                    StartCoroutine(DisplayText());
                }
            }
            else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "foliage")
            {
                if (foliageCollected <= 4)
                {
                    foliageSprite.gameObject.SetActive(true);
                    foliageCollected++;
                    GameObject.Destroy(hit.transform.gameObject);
                    GameObject newFern = Instantiate(rockHolder, hit.transform.position, hit.transform.rotation) as GameObject; // hold transform reference
                    newFern.gameObject.GetComponent<R_RespawnResources>().RespawnFern(); //call respawn function
                    foliageStored.text = foliageCollected.ToString();
                    player.GetComponent<L_playsound>().playSound(4);
                    ShowShelterButton();
                    ShowFireButton();
                }
                else
                {
                    inventoryFullText.gameObject.SetActive(true);
                    StartCoroutine(DisplayText());
                }
            }
            else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "hemp")
            {
                if (hempCollected <= 3)
                {
                    hempSprite.gameObject.SetActive(true);
                    hempCollected++;
                    GameObject.Destroy(hit.transform.gameObject);
                    GameObject newHemp = Instantiate(rockHolder, hit.transform.position, hit.transform.rotation) as GameObject; // hold transform reference
                    newHemp.gameObject.GetComponent<R_RespawnResources>().RespawnHemp(); //call respawn function
                    hempStored.text = hempCollected.ToString();
                    player.GetComponent<L_playsound>().playSound(4);
                    ShowRopeButton();
                    ShowShelterButton();
                }
                else
                {
                    inventoryFullText.gameObject.SetActive(true);
                    StartCoroutine(DisplayText());
                }
            }
            else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "food")
            {
                if (foodCollected <= 4)
                {
                    foodSprite.gameObject.SetActive(true);
                    foodCollected++;
                    GameObject.Destroy(hit.transform.gameObject);
                    GameObject newCoconut = Instantiate(rockHolder, hit.transform.position, hit.transform.rotation) as GameObject; // hold transform reference
                    newCoconut.gameObject.GetComponent<R_RespawnResources>().RespawnCoconut(); //call respawn function
                    foodStored.text = foodCollected.ToString();
                    player.GetComponent<L_playsound>().playSound(4);
                    ShowEatButton();
                }
                else
                {
                    inventoryFullText.gameObject.SetActive(true);
                    StartCoroutine(DisplayText());
                }
            }
            else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "water")
            {
                if (waterCollected < 1)
                {
                    waterSprite.gameObject.SetActive(true);
                    waterCollected++;
                    waterStored.text = waterCollected.ToString();
                    player.GetComponent<L_playsound>().playSound(4);
                    ShowDrinkButton();
                }
                else
                {
                    inventoryFullText.gameObject.SetActive(true);
                    StartCoroutine(DisplayText());
                }
            }
            else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "meat")
            {
                if (meatCollected < 4)
                {
                    meatSprite.gameObject.SetActive(true);
                    cookedmeatSprite.gameObject.SetActive(true);
                    meatCollected++;
                    meatStorred.text = meatCollected.ToString();
                    GameObject.Destroy(hit.transform.gameObject);
                    player.GetComponent<L_playsound>().playSound(4);
                    ShowCookMeatButton();
                }
                else
                {
                    inventoryFullText.gameObject.SetActive(true);
                    StartCoroutine(DisplayText());
                }
            }

            else if(Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "goodBerries")
            {
                if(goodBerriesCollected < 5)
                {
                    goodBerriesCollected++;
                    goodBerriesStored.text = goodBerriesCollected.ToString();
                    Destroy(hit.transform.gameObject);
                    GameObject instance = Instantiate(emptyBush, hit.transform.position, hit.transform.rotation) as GameObject;
                    instance.gameObject.GetComponent<R_respawnGoodBerries>().Respawn();
                    player.GetComponent<L_playsound>().playSound(4);
                    ShowGoodBerryButton();
                }
                else
                {
                    inventoryFullText.gameObject.SetActive(true);
                    StartCoroutine(DisplayText());
                }
            }
            else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "badBerries")
            {
                if (badBerriesCollected < 5)
                {
                    badBerriesCollected++;
                    badBerriesStored.text = badBerriesCollected.ToString();
                    Destroy(hit.transform.gameObject);
                    GameObject instance = Instantiate(emptyBush, hit.transform.position, hit.transform.rotation) as GameObject;
                    instance.gameObject.GetComponent<R_respawnGoodBerries>().RespawnBad();
                    player.GetComponent<L_playsound>().playSound(4);
                    ShowBadBerryButton();
                }
                else
                {
                    inventoryFullText.gameObject.SetActive(true);
                    StartCoroutine(DisplayText());
                }
            }
            else if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "shelter" && gameController.GetComponent<L_gameController>().isItDay == false)
            {
                
                gameController.GetComponent<L_gameController>().Sleep(30);  // calling sleep function from gamecontroller script
                this.GetComponent<L_playerStatChange>().playerEnergy = 100;
                
                
            }
            
            

        }
        
        
    }
    

    public void ShowEatButton()            //these are all checks to see if relevent buttons should be displayed
    {
        if (foodCollected >= 1)
        {
            eatButton.gameObject.SetActive(true);
        }
        else
        {
            eatButton.gameObject.SetActive(false);
        }
     }

    public void ShowRopeButton()
    {
        if(hempCollected >= 1)
        {
            craftropeButton.gameObject.SetActive(true);
        }
        else
        {
            craftropeButton.gameObject.SetActive(false);
        }
    }

    public void ShowFlintButton()
    {
        if(rockCollected >= 1)
        {
            craftflintButton.gameObject.SetActive(true);
        }
        else
        {
            craftflintButton.gameObject.SetActive(false);
        }
    }

    public void ShowStickButton()
    {
        if(woodCollected >= 1)
        {
            craftwoodButton.gameObject.SetActive(true);
        }
        else
        {
            craftwoodButton.gameObject.SetActive(false);
        }
    }

    public void ShowGoodBerryButton()
    {
        if(goodBerriesCollected >= 1)
        {
            goodBerryButton.gameObject.SetActive(true);
        }
        else
        {
            goodBerryButton.gameObject.SetActive(false);
        }
    }

    public void ShowBadBerryButton()
    {
        if(badBerriesCollected >= 1)
        {
            badBerryButton.gameObject.SetActive(true);
        }
        else
        {
            badBerryButton.gameObject.SetActive(false);
        }
    }

    public void ShowShelterButton()
    {
        if(CraftingManager.sticksCollected >= 4 && CraftingManager.ropeCollected >= 2 && foliageCollected >= 4)
        {
            craftShelterButton.gameObject.SetActive(true);
        }
        else
        {
            craftShelterButton.gameObject.SetActive(false);
        }
    }

    public void ShowFireButton()
    {
        if(CraftingManager.sticksCollected >= 8 && rockCollected >= 6)
        {
            craftFireButton.gameObject.SetActive(true);
        }
        else
        {
            craftFireButton.gameObject.SetActive(false);
        }
    }
    public void ShowAxeButton()
    {
        if(CraftingManager.flintCollected >=1 && CraftingManager.sticksCollected >=2 && CraftingManager.ropeCollected >= 1 && CraftingManager.axeCrafted == false)
        {
            craftAxeButton.gameObject.SetActive(true);
        }
        else
        {
            craftAxeButton.gameObject.SetActive(false);
        }
    }

    public void ShowCookMeatButton()
    {
        if(meatCollected >=1 && PlayerMove.atFire == true)
        {
            cookMeatButton.gameObject.SetActive(true);
        }
        else
        {
            cookMeatButton.gameObject.SetActive(false);
        }
    }
    public void ShowEatMeatButton()
    {
        if(R_cookMeat.cookedMeatCollected >= 1)
        {
            eatMeatButton.gameObject.SetActive(true);
        }
        else
        {
            eatMeatButton.gameObject.SetActive(false);
        }
    }

    public void ShowDrinkButton()
    {
        if(waterCollected >= 1)
        {
            drinkButton.gameObject.SetActive(true);
        }
        else
        {
            drinkButton.gameObject.SetActive(false);
        }
    }
}




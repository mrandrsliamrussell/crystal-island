using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_swingAxe : MonoBehaviour
{

    public Camera playerCam;
    public float rayLength;
    public GameObject woodPrefab;
    public GameObject rawMeat;
    public int treeDamage = 1;
    public bool playerBlocking = false;
    public GameObject axe;
    public float swingDelay = 0.5f, attackDelay = 0.5f;
    public GameObject claws;

    
    void Start()
    {
        //swingDelay -= Time.deltaTime;
    }






    void Update()
    {
        swingDelay -= Time.deltaTime;        //counts down from 0.5 seconds to check if player can swing again
        attackDelay -= Time.deltaTime;
        RaycastHit hit;
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && CraftingManager.axeCrafted == true)   //check if player has axe
        {
            axe.GetComponent<Animation>().Play("axeSwing3");   //play axe animation
        }
        if (swingDelay <= 0)
        {
            if (Input.GetMouseButtonDown(0) && CraftingManager.axeCrafted == true)
            {
                if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.gameObject.tag == "tree")
                {


                    hit.transform.GetComponent<DestroyableTree>().HitTree(treeDamage);
                    this.GetComponent<L_playsound>().playSound(0);
                    swingDelay = 0.5f;


                }
                else if (Physics.Raycast(ray, out hit, rayLength))
                {
                    if (attackDelay <= 0)
                    {
                        try
                        {
                            hit.transform.GetComponent<L_JaguarV2>().hit();   //calling hit function from jag script
                            attackDelay = 0.5f;
                        }
                        catch
                        {

                        }
                    }

                }
            }
        }

            if (Input.GetMouseButtonDown(1) && CraftingManager.axeCrafted == true)
            {
                playerBlocking = true; // then play blocking animation
            axe.GetComponent<Animation>().Play("axeBlock3");   //get animation from axe object
            }
            else if (Input.GetMouseButtonUp(1) && CraftingManager.axeCrafted == true)
            {
                playerBlocking = false; //then return axe to normal position
            axe.GetComponent<Animation>().Play("axeBlock4");
            }
        }
    
    }



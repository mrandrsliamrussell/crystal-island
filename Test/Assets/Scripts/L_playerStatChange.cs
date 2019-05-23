using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_playerStatChange : MonoBehaviour {
    public float playerHealth, playerHunger, playerThirst, playerEnergy;
    float timer;
    bool canRegen;
    public GameObject gameoverScreen, player, cam;
	// Use this for initialization
	void Start () {
        playerHealth = 100;
        playerHunger = 100;
        playerThirst = 100;
        playerEnergy = 100;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(playerHunger > 0 && playerThirst > 0)
        {
            canRegen = true;
        }
        if(playerHunger < 1 || playerThirst < 1)
        {
            canRegen = false;
            playerHealth -= 0.25f * Time.deltaTime;
        }

        
        if(playerHealth < 100 && playerHealth > 1 && canRegen == true)
        {
            playerHealth += 0.3f * Time.deltaTime;
        }
        playerHunger -= 0.5f * Time.deltaTime;
        playerThirst -= 0.6f * Time.deltaTime;
        
        if(playerEnergy < 100)
        {
            if(timer > 5){
                timer = 0;
                playerEnergy += 1;
            }
        }
		 if(playerHealth <= 0)
        {
            gameoverScreen.gameObject.SetActive(true);
            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<R_swingAxe>().enabled = false;
            cam.GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
	}
}

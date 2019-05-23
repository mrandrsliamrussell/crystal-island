using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class R_Inventory : MonoBehaviour {

    public GameObject panel;
    bool isInventoryOpen;
    public GameObject Player;
    public GameObject cam;
   
    
    

	// Use this for initialization
	void Start () {
        isInventoryOpen = false;
        panel.gameObject.SetActive(false);
        Player.GetComponent<PlayerMove>().enabled = true;       //enabling scripts
        Player.GetComponent<R_swingAxe>().enabled = true;
        cam.GetComponent<PlayerLook>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isInventoryOpen)
            {
                panel.gameObject.SetActive(false);
                isInventoryOpen = false;
                Player.GetComponent<PlayerMove>().enabled = true;
                Player.GetComponent<R_swingAxe>().enabled = true;
                cam.GetComponent<PlayerLook>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                panel.gameObject.SetActive(true);
                isInventoryOpen = true;
                Player.GetComponent<PlayerMove>().enabled = false;          //prevents player and camera moving when inventory open
                Player.GetComponent<R_swingAxe>().enabled = false;
                cam.GetComponent<PlayerLook>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }
		
	}
    
}

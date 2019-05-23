using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_UI : MonoBehaviour
{
    public Image healthBar, thirstBar, hungerBar, energyBar, hudImage, hudDayTimer, hudDayTimerBackground, healthsprite, thirstsprite, hungersprite, energysprite;
    float health, hunger, thirst, energy;
    public GameObject getPlayerStats, GameController;
    bool canPlaySound;
    // Use this for initialization

    void Start()
    {
        StartCoroutine(flashLights());
    }

    // Update is called once per frame
    void Update()
    {
        health = getPlayerStats.GetComponent<L_playerStatChange>().playerHealth;
        hunger = getPlayerStats.GetComponent<L_playerStatChange>().playerHunger;
        thirst = getPlayerStats.GetComponent<L_playerStatChange>().playerThirst;
        energy = getPlayerStats.GetComponent<L_playerStatChange>().playerEnergy;
        hudDayTimerBackground.transform.rotation = Quaternion.Euler(0, 0, 90 - GameController.GetComponent<L_gameController>().contTimeCounter * GameController.GetComponent<L_gameController>().currentDegree);
        healthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, health);
        thirstBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, thirst);
        hungerBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hunger);
        energyBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, energy);
        if (energy < 0.1f)
        {
            
            StartCoroutine(BreathingDelay());
        }
    }
    IEnumerator flashLights()
    {
        if (health < 20)
        {
            healthsprite.gameObject.SetActive(false);
        }
        if (thirst < 20)
        {
            thirstsprite.gameObject.SetActive(false);
        }
        if (hunger < 20)
        {
            hungersprite.gameObject.SetActive(false);
        }
        if (energy < 20)
        {
            energysprite.gameObject.SetActive(false);

        }
        
        yield return new WaitForSeconds(1);

        healthsprite.gameObject.SetActive(true);
        thirstsprite.gameObject.SetActive(true);
        hungersprite.gameObject.SetActive(true);
        energysprite.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        StartCoroutine(flashLights());
    }
    IEnumerator BreathingDelay()
    {
        if(canPlaySound == true)
        {
            canPlaySound = false;
            getPlayerStats.GetComponent<L_playerStatChange>().player.GetComponent<L_playsound>().playSound(3);
        }
        yield return new WaitForSeconds(3);
        canPlaySound = true;
    }
}

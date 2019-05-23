using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class R_Tutorial : MonoBehaviour
{

    public GameObject controlsText, controlsInventory;


    void Start()
    {
        controlsText.gameObject.SetActive(true);
        StartCoroutine(ControlsText());

    }

    public void ShowControls()
    {
        controlsInventory.gameObject.SetActive(true);
        StartCoroutine(ControlsInventoryText());
    }
    IEnumerator ControlsText()
    {
        yield return new WaitForSeconds(8);
        controlsText.gameObject.SetActive(false);
    }
    IEnumerator ControlsInventoryText()
    {
        yield return new WaitForSeconds(4);
        controlsInventory.gameObject.SetActive(false);
    }
}


	
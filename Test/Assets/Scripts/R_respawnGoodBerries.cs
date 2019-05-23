using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_respawnGoodBerries : MonoBehaviour
{
    public GameObject GoodBerryBush, BadBerryBush;

    public void Respawn()
    {
        StartCoroutine(RespawnGoodBerries());

    }
    public void RespawnBad()
    {
        StartCoroutine(RespawnBadBerries());
    }

    IEnumerator RespawnGoodBerries()
    {
        
        yield return new WaitForSeconds(60);         //wait 60 seconds, call respawn function
        GoodBerries();
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }
    IEnumerator RespawnBadBerries()
    {
        yield return new WaitForSeconds(60);
        BadBerries();
        this.gameObject.SetActive(false);
    }

    public void GoodBerries()
    {
        Instantiate(GoodBerryBush, this.transform.position, this.transform.rotation);     //respawn relevent bush, using transform holder(from R_Pickuptext script) object spawned when object first collected
    }
    public void BadBerries()
    {
        Instantiate(BadBerryBush, this.transform.position, this.transform.rotation);
    }

}






using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_RespawnResources : MonoBehaviour
{

    public GameObject rockPrefab, hempPrefab, fernPrefab, coconutPrefab;
    

    public void RespawnRock()
    {
        StartCoroutine(Rock());
    }

    public void RespawnHemp()
    {
        StartCoroutine(Hemp());
    }

    public void RespawnFern()
    {
        StartCoroutine(Fern());
    }

    public void RespawnCoconut()
    {
        StartCoroutine(Coconut());
    }

    IEnumerator Rock()
    {
        yield return new WaitForSeconds(60);
        GameObject thisRock = Instantiate(rockPrefab, this.transform.position, this.transform.rotation) as GameObject;
    }

    IEnumerator Hemp()
    {
        yield return new WaitForSeconds(60);
        GameObject thisHemp = Instantiate(hempPrefab, this.transform.position, this.transform.rotation) as GameObject;
    }

    IEnumerator Fern()
    {
        yield return new WaitForSeconds(60);
        GameObject thisFern = Instantiate(fernPrefab, this.transform.position, this.transform.rotation) as GameObject;
    }

    IEnumerator Coconut()
    {
        yield return new WaitForSeconds(60);
        GameObject thisCoconut = Instantiate(coconutPrefab, this.transform.position, this.transform.rotation) as GameObject;
    }
}


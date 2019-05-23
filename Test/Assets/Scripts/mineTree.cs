using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineTree : MonoBehaviour
{

    public GameObject woodPrefab;
    public int treeHits = 3;
    public GameObject treePrefab;
    

    
    
    public void HitTree(int amount)
    {
        treeHits -= amount;

        if (treeHits <= 0)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            StartCoroutine(DestroyTree());
        }
    }

    IEnumerator DestroyTree()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        Instantiate(woodPrefab, transform.position, transform.rotation);
        Instantiate(woodPrefab, transform.position + transform.forward * 2, transform.rotation);
    }
}

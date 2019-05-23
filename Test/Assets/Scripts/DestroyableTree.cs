using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableTree : MonoBehaviour
{

    public int terrainIndex;
    public GameObject woodPrefab;
    public int treeHits = 3;
    public GameObject treePrefab;
    
    // this script stores information about a tree on the terrain and how many hits it has left from the axe, when its destroyed it removes itself from the terrain, spawn a tree that falls and then gives tha player wood.
    

    public void HitTree(int amount)
    {
        treeHits -= amount;

        if (treeHits == 0)
        {
            GameObject myTree = Instantiate(treePrefab, transform.position, transform.rotation);
            myTree.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
            
           

            StartCoroutine(DestroyTree());

        }
    }

    IEnumerator DestroyTree()
    {
        Delete();
        yield return new WaitForSeconds(5);
  

    }

    public void Delete()
    {
        Terrain terrain = Terrain.activeTerrain;

        List<TreeInstance> trees = new List<TreeInstance>(terrain.terrainData.treeInstances);
        trees[terrainIndex] = new TreeInstance();
        terrain.terrainData.treeInstances = trees.ToArray();

        Destroy(gameObject);
    }
}

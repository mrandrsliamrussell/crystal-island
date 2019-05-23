using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class TreeTerrain : MonoBehaviour
{
    public Terrain terrain;
    private TreeInstance[] _originalTrees;
    public GameObject quitText;
    public GameObject palmtreePrefab;
    public GameObject foresttreePrefab;
    public GameObject woodPrefab;
   // this was written by both liam and richard with much swearing and many failures and fag breaks
    // public CapsuleCollider capsuleCollider;
    void Start()
    {
        terrain = GetComponent<Terrain>();

        // backup original terrain trees
        _originalTrees = terrain.terrainData.treeInstances;
      
        // create capsule collider for every terrain tree
        for (int i = 0; i < terrain.terrainData.treeInstances.Length; i++)
        {
            TreeInstance treeInstance = terrain.terrainData.treeInstances[i];
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);


            capsule.transform.GetComponent<CapsuleCollider>().center = new Vector3(0, 1.1f, 0);
            capsule.transform.localScale = new Vector3(2f, 5, 2f);

            DestroyableTree tree = capsule.AddComponent<DestroyableTree>(); // adds the destroyable tree script to the trees on the terrain
           
            //Debug.Log(treeInstance.prototypeIndex.ToString());
            if (treeInstance.prototypeIndex == 1)
             {
                 capsule.GetComponent<DestroyableTree>().treePrefab = foresttreePrefab;
             }
             else if(treeInstance.prototypeIndex == 0) //this lets the script on each tree know what type of tree to spawn when its cut down by looking at tis index on the tree terrain editor
             {
                 capsule.GetComponent<DestroyableTree>().treePrefab = palmtreePrefab;
             }
            tree.terrainIndex = i;

            capsule.transform.position = Vector3.Scale(treeInstance.position, terrain.terrainData.size);
            capsule.tag = "tree";
            capsule.transform.parent = terrain.transform;
            capsule.GetComponent<Renderer>().enabled = false;
        }
    }
    void OnApplicationQuit()
    {
        // restore original trees
        terrain.terrainData.treeInstances = _originalTrees;
    }
    public void DisplayQuitText()
    {
        quitText.gameObject.SetActive(true);
    }
    public void QuitGame()
    {
        terrain.terrainData.treeInstances = _originalTrees;
        SceneManager.LoadScene("Main_Menu");
    }
    public void ReturnToGame()
    {
        quitText.gameObject.SetActive(false);
    }
    
    public void GameoverRestart()
    {
        terrain.terrainData.treeInstances = _originalTrees;
        SceneManager.LoadScene("Final Island V3");
    }

    public void GameoverQuit()
    {
        terrain.terrainData.treeInstances = _originalTrees;
        SceneManager.LoadScene("Main_Menu");
    }
}

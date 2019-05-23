using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestroyTimer : MonoBehaviour {
    public GameObject woodPrefab;
    Vector3 Pos, Pos2;
	// Use this for initialization
	void Start () {
        StartCoroutine(destroySelf());
        Pos = new Vector3(0f, 2f, 0f);
        Pos2 = new Vector3(5f, 2f, 0f);
    }
	
	IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        Instantiate(woodPrefab, (transform.position + Pos), transform.rotation);
        Instantiate(woodPrefab, (transform.position + Pos2), transform.rotation);
    }
}

using UnityEngine;
using System.Collections;

public class grass_script : MonoBehaviour {
    Renderer rend;
    public bool active = false;
    public float amp = 1;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {

       
        
        if (active == true)
        {
            if (amp > 0.1)
            {
                amp = amp * 0.90f;
                rend.material.SetFloat("_OffsetX", amp/2);

                rend.material.SetFloat("_OffsetZ", amp/2);
              
            }
            else
            {
                active = false;
                amp = 0;
                amp = 1;
                
            }

        }
        else
        {
            rend.material.SetFloat("_OffsetX", 0);

            rend.material.SetFloat("_OffsetZ", 0);
            
        }
    }
   
}

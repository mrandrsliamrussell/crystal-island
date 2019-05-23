using UnityEngine;
using System.Collections;

public class Collision_script : MonoBehaviour
{

    public Renderer rend;
    public bool active = false;
    Vector3 prevPos, currVel;
    float amp = 1;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (prevPos != null)
        {
            currVel = (prevPos - transform.position) / Time.deltaTime;
           
        }
        prevPos = transform.position;
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.GetComponent<grass_script>() != null)
        {
            col.gameObject.GetComponent<grass_script>().active = true;
            col.gameObject.GetComponent<grass_script>().amp = currVel.magnitude; //using speed to increase the force of shaking when running through ferns
            
        }

    }
}


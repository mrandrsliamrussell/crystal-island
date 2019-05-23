using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class L_wolfPackLocation : MonoBehaviour {
    public Vector3 goal;
    
    public float dayRadius, nightRadius;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal;
       
    }
} // this script sets the distances for the day and night patrol locations for the Ai system and although its not being used this script has its own ai so that a pack of wolves could patrol
// as a group around the map if needed.

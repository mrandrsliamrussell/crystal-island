using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class L_WolfAI : MonoBehaviour {
    
    
    public Vector3 goal, prevPosition, currantPosition;
    public GameObject FOV, player, biteZone, wolfModel;
    float distanceFromPlayer;
    bool canAttack = true , isRunning = false;
    public bool isAttacking = false;
    

    Vector3 playerDirection;
   public Vector3 attackGoal, distance;
    
	// Use this for initialization
	void Awake () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        prevPosition = this.transform.position;
    }
   
	
	// Update is called once per frame
/*	void Update () {


        
     





            distanceFromPlayer = Vector3.Distance(player.transform.position, this.transform.position);
      //  Debug.Log(FOV.GetComponentInChildren<L_wolfFOV>().canSeePlayer);
            if (FOV.GetComponentInChildren<L_wolfFOV>().canSeePlayer == true && isAttacking == false) //chasing
            {
        
            NavMeshAgent agent = GetComponent<NavMeshAgent>();

                agent.speed = 6;

                agent.acceleration = 8;
                goal = player.transform.position;
                agent.destination = goal;
               Debug.Log("target found");
            isRunning = true;
            //attacking


        }
            else if (FOV.GetComponentInChildren<L_wolfFOV>().canSeePlayer == false && isAttacking == false) //patroling
            {
            isRunning = false;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.speed = 3.5f;
                agent.acceleration = 8;
                //wolfModel.GetComponent<Animation>().Play("walk_anim");


            agent.destination = goal;
                //Debug.Log("target lost");

                if (distanceFromPlayer < 5 && canAttack == true)
                {



                goal =  player.transform.position - this.transform.position ;
                goal = goal* 1.5f + player.transform.position;
                
                    agent.destination = goal;

                    agent.speed = 20;
                    agent.acceleration = 60;
                    Debug.Log("attacking");
                    isAttacking = true;
                    StartCoroutine(attackCooldown());
                }
                
            }
            if(isAttacking == true)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();

            agent.destination = goal;
            if (Mathf.RoundToInt(goal.x) == Mathf.RoundToInt(this.transform.position.x) && Mathf.RoundToInt(goal.z) == Mathf.RoundToInt(this.transform.position.z))
            {
                
                Debug.Log("finished attacking");
                isAttacking = false;
                agent.speed = 3.5f;
                agent.acceleration = 8;

            }
        }
        prevPosition = this.transform.position;


        if (this.GetComponent<Rigidbody>().IsSleeping() == true) //checks if standing still to play idle animation
        {
            Debug.Log("playing idle anim");
            wolfModel.GetComponent<Animation>().Play("idle_anim");
        }
        else if (this.GetComponent<Rigidbody>().IsSleeping() == false)
        {
            Debug.Log("playing walk anim");
            wolfModel.GetComponent<Animation>().Play("walk_anim");
        }
        else if (this.GetComponent<Rigidbody>().IsSleeping() == false && isRunning == true)
        {
            Debug.Log("playing run anim");
            wolfModel.GetComponent<Animation>().Play("run_anim");
        }
    }
    IEnumerator attackCooldown()
    {
        canAttack = false;
      
       
        yield return new WaitForSeconds(5);
        canAttack = true;
        isAttacking = false;
    }*/
   
   

}

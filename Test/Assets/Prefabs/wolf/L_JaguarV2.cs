using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class L_JaguarV2 : MonoBehaviour
{
    public GameObject jagMesh, jagView, jagAttackBox, AiController, player, rawMeat;
    public Collider jagViewCol, jagAttackCol;
    public Vector3 goal;
    public NavMeshAgent agent;
    bool canAttack = true, isAttacking;
    public bool hasAttacked, canSee, isDying = false, canPlaySound = true;
    public int health = 5, listIndex;
    [SerializeField]
    float distanceFromPlayer, i,j;
    GameObject newMeat;
    void Awake()
    {
         agent = GetComponent<NavMeshAgent>();
        jagViewCol = jagView.GetComponent<Collider>();
        jagAttackCol = jagAttackBox.GetComponent<Collider>();
        this.transform.GetComponent<NavMeshAgent>().Warp(AiController.transform.position);

    } //the awake method assigns the attack hitbox and view colliders from the specific jaguars children as well as moving the jaguar to its starting position.

  

    // Update is called once per frame
    void Update()
    {
        
        
        distanceFromPlayer = Vector3.Distance(player.transform.position, this.transform.position); //the distance from player calculation decides what the jaguar should be doing further down in the script, whether it should be running or walking or attacking the player.
    
        if (canSee == true && isAttacking == false) //bacause of the way the AI flowchart is deigned, actions at the bottom have to be checked first and if they return false the chain moves up the stack looking for less strict conditions
        {
            chase(player);
            StartCoroutine(playSoundTimer());

        }
        else if (canSee == false)
        {
            patrol(goal);
           
        }
        else if (isAttacking == true)
        {

            while (i > jagMesh.GetComponent<Animation>().GetClip("attack_anim").length) //this sets a timer that waits until the jaguar attack animation has finished playing.
            {
                
                isAttacking = false;
                i = 0;
                if (hasAttacked == true)
                {
                    Debug.Log("player bitten");
                    if (player.GetComponent<R_swingAxe>().playerBlocking == false)
                    {
                        player.GetComponent<L_playerStatChange>().playerHealth -= 30;
                        player.GetComponent<CraftingManager>().DisplayClaws();
                    }
                }
            }
            i += Time.deltaTime;
            jagMesh.GetComponent<Animation>().Play("attack_anim");

        }
        if (health < 1)
        {
            die();
            isDying = true;
        }// this kills the jaguar when health runs out
    }
    public void patrol(Vector3 position)
    {
      
        agent.speed = 3.5f;
        agent.acceleration = 8;
        agent.destination = position;
        if (this.GetComponent<Rigidbody>().IsSleeping() == true) //checks if standing still to play idle animation through use of physics
        {

            jagMesh.GetComponent<Animation>().CrossFade("idle_anim"); //the crossfade method blends animations togeather for a smoother effect

        }
        else if (this.GetComponent<Rigidbody>().IsSleeping() == false)
        {
            
            jagMesh.GetComponent<Animation>().CrossFade("walk_anim");
        }

    }
    public void chase(GameObject player)
    {

        jagMesh.GetComponent<Animation>().CrossFade("run_anim");
    
        agent.speed = 8f;
        agent.acceleration = 8; // when chasing the player speed increases
        agent.destination = player.transform.position;

        if (canSee == false)
        {
            patrol(goal); // if the player is out of sight then return back to last patrol position
        }
        if (distanceFromPlayer < 6) // i chose to slow down the jaguar when close to give a stalking effect 
        {
            agent.speed = 3.5f;
            jagMesh.GetComponent<Animation>().CrossFade("walk_anim");
            if (distanceFromPlayer < 2) // this is the range in which the jaguar will start to attack the player
            {
                jagAttackBox.SetActive(true);
                jagMesh.GetComponent<Animation>().CrossFade("idle_anim");
                if (canAttack == true)
                {
                    attack(player);
                    agent.destination = this.transform.position;

                    Debug.Log("attacking");
                }
            }
        
        }
    }
    void attack(GameObject player)
    {

        StartCoroutine(attackCooldown());
    }
    public void hit()
    {
        jagMesh.GetComponent<Animation>().CrossFade("damage_anim");
        health -= 1;

    }
    void die()
    {
        
        
        if (isDying == true)
        
            {
                
                StartCoroutine(RespawnTimer());
                
            }       
        
    }
    public void biteTrigger(Collider objectCol)
    {
        if (objectCol == player)
        {
            hasAttacked = true;
        }
        else
        {
            hasAttacked = false;
        }
    }
    IEnumerator attackCooldown() //stops the jaguar attacking every second
    {
        canAttack = false;
        isAttacking = true;

        agent.destination = this.transform.position;


        yield return new WaitForSeconds(5);
        canAttack = true;
        isAttacking = false;
    }
    IEnumerator RespawnTimer()
    {
        jagMesh.GetComponent<Animation>().Play("death_anim");
        yield return new WaitForSeconds(0.8f);
        if (isDying == true)
        {
            newMeat = (GameObject)Instantiate(rawMeat, this.transform.position, Quaternion.identity);
            Destroy(newMeat, 30);
            health = 5;
            isDying = false;
            this.transform.position = AiController.transform.position;
            if(distanceFromPlayer < 50)
            {
                AiController.GetComponent<L_AIManager>().respawnIndexList.Add(listIndex); // this tells the AI manager what jaguar has died and stores that information so this script can be set active again when its time to respawn
                
                this.gameObject.SetActive(false);
            }
        }
       

    }
    IEnumerator playSoundTimer()
    {
        

        if(canPlaySound == true)
        {
            this.GetComponent<L_playsound>().playSound(0);
            canPlaySound = false;
        }

        yield return new WaitForSeconds(30);
        canPlaySound = true;
    }
  

    }
    


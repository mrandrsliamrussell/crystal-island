using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    CharacterController charControl;

    float walkSpeed = 8;
    float sideSpeed = 4;
    public bool isInWater = false;   //check if player is in water - can use this in drinking/health script
    public bool isInSea = false;
    private float verticalVelocity, verticalVelocityBuffer;
    private float gravity = 10.0f;
    private float jumpForce = 12.0f;
    public float sendDamage;
    public static bool atFire = false;   //used to check if player is by fire to cook meat
    public GameObject FirePlace, player;
    

    void Awake()
    {
        
        charControl = GetComponent<CharacterController>();
        atFire = false;
    }

    void Update()
    {
        movePlayer();
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0 && isInWater == false && isInSea == false && this.GetComponent<L_playerStatChange>().playerEnergy > 0)
        {
            walkSpeed = 15;  //player can sprint when not in water
            this.GetComponent<L_playerStatChange>().playerEnergy -= walkSpeed * 0.4f* Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isInWater == false && isInSea == false)
        {
            walkSpeed = 8;    //return to normal speed when shift released
            sideSpeed = 4;
        }
        if (charControl.isGrounded)                //check if player is touching ground they can jump (to prevent infinite jump loop)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
          
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            verticalVelocityBuffer = verticalVelocity;

        }
        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        charControl.Move(moveVector * Time.deltaTime);

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "water")     //check if player has hit water volume
        {
            isInWater = true;
            walkSpeed = 5;                        //slow walkspeed
            sideSpeed = 2;
        }
        else if (other.gameObject.tag == "sea")
        {
            isInSea = true;
            walkSpeed = 5;
            sideSpeed = 2;
        }
        else if(other.gameObject.tag == "fireplace")
        {
            atFire = true;
            player.GetComponent<R_Pickuptext>().ShowCookMeatButton();          //if player is by fire, call ShowCookMeatButton() to check if player has meat, if they have display cook button
           
        }
    }
   
    void OnTriggerExit(Collider other)           //check when player leaves volumes
    {
        if (other.gameObject.tag == "water")
        {
            walkSpeed = 8;
            sideSpeed = 4;
            isInWater = false;
        }
        else if (other.gameObject.tag == "sea")
        {
            walkSpeed = 8;
            sideSpeed = 4;
            isInSea = false;
        }
        else if(other.gameObject.tag == "fireplace")
        {
            atFire = false;
            player.GetComponent<R_Pickuptext>().ShowCookMeatButton();
        }
    }

    

    void movePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * horiz * sideSpeed;              //move player sideways at walkspeed
        Vector3 moveDirForward = transform.forward * vert * walkSpeed;          //move player foward at walkspeed   

        charControl.SimpleMove(moveDirSide);
        charControl.SimpleMove(moveDirForward);
    }

}


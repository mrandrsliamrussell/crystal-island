using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    public float mouseSensitivity;
    public Transform playerBody;
    float xaxisClamp = 0;             //clamp rotation to prevent camera flipping
   
    
    
	void Update()
    {
      
            mouseSensitivity = 60 + L_MenuUI.GlobalMouseSensitivity;
      
        RotateCamera();
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity * Time.deltaTime;
        float rotAmountY = mouseY * mouseSensitivity * Time.deltaTime;

        xaxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;                 
        targetRotCam.z = 0;                           
        targetRotBody.y += rotAmountX;
       
                    
        
        if(xaxisClamp > 80 )                           //clamp camera when looking straight down
        {
            xaxisClamp = 80 - rotAmountX;
            //Debug.Log(xaxisClamp);
            targetRotCam.x = 80;
            targetRotCam.z = 0;
            //targetRotCam.x = Mathf.RoundToInt(targetRotCam.x);
        }
        else if(xaxisClamp < -80)                  // clamp camera when looking up
        {
            xaxisClamp = -80 + rotAmountX;
            //Debug.Log(xaxisClamp);
            targetRotCam.x = 280;                //when quaternion to Euler straight up is 270
            targetRotCam.z = 0;
            //targetRotCam.y = Mathf.RoundToInt(targetRotCam.y);
        }

        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);


    }
}

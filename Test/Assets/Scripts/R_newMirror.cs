using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_newMirror : MonoBehaviour {

    public GameObject mirror1, testRay, spinWheel, crystalRay;
    public GameObject mirror2, ray2, spinWheel2;
    public GameObject mirror3, ray3, spinWheel3;
    public GameObject mirror4, ray4, spinWheel4;
    public GameObject mirror5, ray5, spinWheel5;
    public Camera playerCam;
    public GameObject player;
    public float mirrorRayLength;
    public int mirrorAngle = 0, mirror2Angle = 0, mirror3Angle = 0, mirror4Angle = 0, mirror5Angle = 0;
    public bool mirrorCorrect = false, mirror2Correct = false, mirror3Correct = false, mirror4Correct = false, mirror5Correct = false;
    public bool canRotateCW = true, canRotateACW = true;
    public bool canRotateCW2 = true, canRotateACW2 = true;
    public bool canRotateCW3 = true, canRotateACW3 = true;
    public bool canRotateCW4 = true, canRotateACW4 = true;
    public bool canRotateCW5 = true, canRotateACW5 = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Ray mirrorRay = playerCam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(mirrorRay, out hit, mirrorRayLength) && hit.transform.gameObject.tag == "mirror1" && canRotateCW == true)
            {
                if (mirrorAngle <= 20)
                {
                    mirror1.transform.Rotate(0, 10, 0);      //one turn = 10 dgrees rotation, add 1 to score
                    mirrorAngle++;
                    player.GetComponent<L_playsound>().playSound(5);
                    AngleCheck();
                    ShowCrystalRay();
                    canRotateACW = true;
                    spinWheel.transform.Rotate(0, 0, 10);  //turns crank

                }
                else if (mirrorAngle >= 20)
                {
                    canRotateCW = false;                          //limit rotation to 200 degrees so it cant continually spin
                    //mirrorAngle = mirrorAngle;
                    AngleCheck();
                    ShowCrystalRay();
                    canRotateACW = true;
                    
                }
            }
            else if (Physics.Raycast(mirrorRay, out hit, mirrorRayLength) && hit.transform.gameObject.tag == "mirror2" && canRotateCW2 == true)
            {
                if (mirror2Angle <= 20)
                {
                    mirror2.transform.Rotate(0, 10, 0);
                    mirror2Angle++;
                    player.GetComponent<L_playsound>().playSound(5);
                    Angle2Check();
                    ShowCrystalRay();
                    canRotateACW2 = true;
                    spinWheel2.transform.Rotate(0, 0, 10);
                }
                else if (mirror2Angle >= 20)
                {
                    canRotateCW2 = false;
                    Angle2Check();
                    ShowCrystalRay();
                    canRotateACW2 = true;
                }
            }
            else if (Physics.Raycast(mirrorRay, out hit, mirrorRayLength) && hit.transform.gameObject.tag == "mirror3" && canRotateCW3 == true)
            {
                if (mirror3Angle <= 20)
                {
                    mirror3.transform.Rotate(0, 10, 0);
                    mirror3Angle++;
                    player.GetComponent<L_playsound>().playSound(5);
                    Angle3Check();
                    ShowCrystalRay();
                    canRotateACW3 = true;
                    spinWheel3.transform.Rotate(0, 0, 10);
                }
                else if (mirror3Angle >= 20)
                {
                    canRotateCW3 = false;
                    Angle3Check();
                    ShowCrystalRay();
                    canRotateACW3 = true;
                }
            }
            else if (Physics.Raycast(mirrorRay, out hit, mirrorRayLength) && hit.transform.gameObject.tag == "mirror4" && canRotateCW4 == true)
            {
                if (mirror4Angle <= 20)
                {
                    mirror4.transform.Rotate(0, 10, 0);
                    mirror4Angle++;
                    player.GetComponent<L_playsound>().playSound(5);
                    Angle4Check();
                    ShowCrystalRay();
                    canRotateACW4 = true;
                    spinWheel4.transform.Rotate(0, 0, 10);
                }
                else if (mirror4Angle >= 20)
                {
                    canRotateCW4 = false;
                    Angle4Check();
                    ShowCrystalRay();
                    canRotateACW4 = true;
                }
            }
            else if (Physics.Raycast(mirrorRay, out hit, mirrorRayLength) && hit.transform.gameObject.tag == "mirror5" && canRotateCW5 == true)
            {
                if (mirror5Angle <= 20)
                {
                    mirror5.transform.Rotate(0, 10, 0);
                    mirror5Angle++;
                    player.GetComponent<L_playsound>().playSound(5);
                    Angle5Check();
                    ShowCrystalRay();
                    canRotateACW5 = true;
                    spinWheel5.transform.Rotate(0, 0, 10);
                }
                else if (mirror5Angle >= 20)
                {
                    canRotateCW5 = false;
                    Angle5Check();
                    ShowCrystalRay();
                    canRotateACW5 = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            if (Physics.Raycast(mirrorRay, out hit, mirrorRayLength) && hit.transform.gameObject.tag == "mirror1" && canRotateACW == true)
            {
                if (mirrorAngle >= -20)
                {
                    mirror1.transform.Rotate(0, -10, 0);   //do the opposite, subtract 1 for each turn
                    mirrorAngle -= 1;
                    player.GetComponent<L_playsound>().playSound(5);
                    AngleCheck();
                    ShowCrystalRay();
                    canRotateCW = true;
                    spinWheel.transform.Rotate(0, 0, -10);
                }
                else if (mirrorAngle <= -20)
                {
                    canRotateACW = false;
                    //mirrorAngle = mirrorAngle;
                    AngleCheck();
                    ShowCrystalRay();
                    canRotateCW = true;
                }
            }
            else if (Physics.Raycast(mirrorRay, out hit, mirrorRayLength) && hit.transform.gameObject.tag == "mirror2" && canRotateACW2 == true)
            {
                if (mirror2Angle >= -20)
                {
                    mirror2.transform.Rotate(0, -10, 0);
                    mirror2Angle -= 1;
                    player.GetComponent<L_playsound>().playSound(5);
                    Angle2Check();
                    ShowCrystalRay();
                    canRotateCW2 = true;
                    spinWheel2.transform.Rotate(0, 0, -10);
                }
                else if(mirror2Angle <= -20)
                {
                    canRotateACW2 = false;
                    Angle2Check();
                    ShowCrystalRay();
                    canRotateCW2 = true;
                }
            }
            else if (Physics.Raycast(mirrorRay, out hit, mirrorRayLength) && hit.transform.gameObject.tag == "mirror3" && canRotateACW3 == true)
            {
                if (mirror3Angle >= -20)
                {
                    mirror3.transform.Rotate(0, -10, 0);
                    mirror3Angle -= 1;
                    player.GetComponent<L_playsound>().playSound(5);
                    Angle3Check();
                    ShowCrystalRay();
                    canRotateCW3 = true;
                    spinWheel3.transform.Rotate(0, 0, -10);
                }
                else if (mirror3Angle <= -20)
                {
                    canRotateACW3 = false;
                    Angle3Check();
                    ShowCrystalRay();
                    canRotateCW3 = true;
                }
            }
            else if (Physics.Raycast(mirrorRay, out hit, mirrorRayLength) && hit.transform.gameObject.tag == "mirror4" && canRotateACW4 == true)
            {
                if (mirror4Angle >= -20)
                {
                    mirror4.transform.Rotate(0, -10, 0);
                    mirror4Angle -= 1;
                    player.GetComponent<L_playsound>().playSound(5);
                    Angle4Check();
                    ShowCrystalRay();
                    canRotateCW4 = true;
                    spinWheel4.transform.Rotate(0, 0, -10);
                }
                else if (mirror4Angle <= -20)
                {
                    canRotateACW4 = false;
                    Angle4Check();
                    ShowCrystalRay();
                    canRotateCW4 = true;
                }
            }
            else if (Physics.Raycast(mirrorRay, out hit, mirrorRayLength) && hit.transform.gameObject.tag == "mirror5" && canRotateACW5 == true)
            {
                if (mirror5Angle >= -20)
                {
                    mirror5.transform.Rotate(0, -10, 0);
                    mirror5Angle -= 1;
                    player.GetComponent<L_playsound>().playSound(5);
                    Angle5Check();
                    ShowCrystalRay();
                    canRotateCW5 = true;
                    spinWheel5.transform.Rotate(0, 0, -10);
                }
                else if (mirror5Angle <= -20)
                {
                    canRotateACW5 = false;
                    Angle5Check();
                    ShowCrystalRay();
                    canRotateCW5 = true;
                }
            }
        }
        
    }
    public void AngleCheck()
    {
        if(mirrorAngle == 18 || mirrorAngle == -18)       // if score is 18 or -18 mirror is in place
        {
            mirrorCorrect = true;
            testRay.gameObject.SetActive(true);
            ShowCrystalRay();                  //checking if temple crystal ray should be active
           //Debug.Log("mirrortrue");
        }
        else
        {
            mirrorCorrect = false;
            testRay.gameObject.SetActive(false);
            ShowCrystalRay();
            //Debug.Log("mirrorfalse");
        }
    }
    public void Angle2Check()
    {
        if (mirror2Angle == 18 || mirror2Angle == -18)
        {
            mirror2Correct = true;
            ray2.gameObject.SetActive(true);
            ShowCrystalRay();
        }
        else
        {
            mirror2Correct = false;
            ray2.gameObject.SetActive(false);
            ShowCrystalRay();
        }
    }
    public void Angle3Check()
    {
        if (mirror3Angle == 18 || mirror3Angle == -18)
        {
            mirror3Correct = true;
            ray3.gameObject.SetActive(true);
            ShowCrystalRay();
        }
        else
        {
            mirror3Correct = false;
            ray3.gameObject.SetActive(false);
            ShowCrystalRay();
        }
    }
    public void Angle4Check()
    {
        if (mirror4Angle == 18 || mirror4Angle == -18)
        {
            mirror4Correct = true;
            ray4.gameObject.SetActive(true);
            ShowCrystalRay();
        }
        else
        {
            mirror4Correct = false;
            ray4.gameObject.SetActive(false);
            ShowCrystalRay();
        }
    }
    public void Angle5Check()
    {
        if (mirror5Angle == 18 || mirror5Angle == -18)
        {
            mirror5Correct = true;
            ray5.gameObject.SetActive(true);
            ShowCrystalRay();
        }
        else
        {
            mirror5Correct = false;
            ray5.gameObject.SetActive(false);
            ShowCrystalRay();
        }
    }
    public void ShowCrystalRay()          //if all mirrors aligned show crystal ray
    {
        if(mirrorCorrect == true && mirror2Correct == true && mirror3Correct == true && mirror4Correct == true && mirror5Correct == true)
        {
            crystalRay.gameObject.SetActive(true);
        }
        else
        {
            crystalRay.gameObject.SetActive(false);
        }
    }
}

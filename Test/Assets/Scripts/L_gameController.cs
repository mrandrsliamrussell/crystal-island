using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_gameController : MonoBehaviour
{
    [SerializeField]
    float dayLengthInMinutes, nightLengthInMinutes; // these are serialized rather than public as only this script needs access to them however the game designer needs to adjust the values depending on the length of the day
    public int dayCount;
    public Text dayNumber;
    public float timeCounter, contTimeCounter, dayDegree, nightDegree, overflow, currentDegree, dayNightRatio, nightDayRatio;
    public bool isSleeping, isItDay = true;
    public GameObject player, cam;
    public GameObject Day5GameOver, winScreen;
    // Use this for initialization
    void Start()
    {

        dayDegree = 180.01f / (dayLengthInMinutes * 60);
        nightDegree = 180.01f / (nightLengthInMinutes * 60);

        dayNightRatio = dayLengthInMinutes / nightLengthInMinutes;
        nightDayRatio = nightLengthInMinutes / dayLengthInMinutes;
    }// this script went through many rewrites at first using co routines but in the end we ended up overcomplicating it, we fell back on using purely maths.
    // the start method takes the time its either day or night and divides it by the time to get the number of degrees needed to rotate per second, its 180.01 degrees as if we wernt over halfway the gameobject wouldnt know which way to rotate as it goes to that rotation instead of advancing by that rotation

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        contTimeCounter += Time.deltaTime; //timeCounter counts the time passed in the current half day cycle while contTimeCounter counts the overall game time elapsed, 
        //when its night contTimeCounter's value is adjusted by the ratio of day to night as they revolve at different speeds otherwise the cun would skip ahead as a second per degree during the day doesnt equal a secone per degree at night, this took a lot of working out.
        if (timeCounter > dayLengthInMinutes * 60 && isItDay == true)
        {
            isItDay = false;
            timeCounter = 0 + overflow;
            overflow = 0;
            contTimeCounter = contTimeCounter / dayNightRatio;
            
        }
        else if (timeCounter > nightLengthInMinutes * 60 && isItDay == false)
        {
            isItDay = true;
            this.GetComponent<L_playsound>().playSound(0);
            timeCounter = 0 + overflow;
            dayCount += 1;
            overflow = 0;
            contTimeCounter = contTimeCounter * dayNightRatio;
            dayNumber.text = dayCount.ToString();
            Day5Lose();
            Win();
        }

        if (isItDay == true) //the public isItDay variable determines many things including wolf activity and also counts the days as it oscilates from on to off
        {
            this.transform.localRotation = Quaternion.Euler(contTimeCounter * dayDegree, 0, 0);
            currentDegree = dayDegree;     
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(contTimeCounter * nightDegree, 0, 0);
            currentDegree = nightDegree;       
        }

    }
    
    public void Sleep(int sleepTime) // richard wrote this method
    {
        if (isItDay == false && (nightLengthInMinutes * 60) - timeCounter > sleepTime)
        {
            contTimeCounter += sleepTime;
            timeCounter += sleepTime;
            player.GetComponent<L_playerStatChange>().playerHunger -= 50;
            player.GetComponent<L_playerStatChange>().playerThirst -= 50;
        }
        else if (isItDay == false && (nightLengthInMinutes * 60) - timeCounter < sleepTime)
        {
            overflow = (nightLengthInMinutes * 60) - timeCounter;
        }
    }
    public void Day5Lose() //richard wrote this method
    {
        if(dayCount == 5 && player.GetComponent<R_newMirror>().mirrorCorrect == false && player.GetComponent<R_newMirror>().mirror2Correct == false && player.GetComponent<R_newMirror>().mirror3Correct == false && player.GetComponent<R_newMirror>().mirror4Correct == false && player.GetComponent<R_newMirror>().mirror5Correct == false)
        {
            Day5GameOver.gameObject.SetActive(true);
            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<R_swingAxe>().enabled = false;
            cam.GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Win() // richard wrote this method
    {
        if (dayCount == 5 && player.GetComponent<R_newMirror>().mirrorCorrect == true && player.GetComponent<R_newMirror>().mirror2Correct == true && player.GetComponent<R_newMirror>().mirror3Correct == true && player.GetComponent<R_newMirror>().mirror4Correct == true && player.GetComponent<R_newMirror>().mirror5Correct == true)
        {
            winScreen.gameObject.SetActive(true);
            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<R_swingAxe>().enabled = false;
            cam.GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

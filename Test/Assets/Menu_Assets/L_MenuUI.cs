using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class L_MenuUI : MonoBehaviour {
    public Button startGame, options, quitGame;
    public PlayableDirector animationController, plane;
    public Slider volume, mouseSns;
    public Image optionsBG;
    public static float globalVolumeLevel, GlobalMouseSensitivity;
    bool doOnceLatch = false, onOptions = false;
	// Use this for initialization
	void Start () {
        volume.gameObject.SetActive(false);
        mouseSns.gameObject.SetActive(false);
        optionsBG.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        startGame.onClick.AddListener(StartGame);
        quitGame.onClick.AddListener(QuitGame);
        if (onOptions == false)
        {
            options.onClick.AddListener(GoToOptions);
        }
        else
        {
            options.onClick.AddListener(optionsQuit);
        }
        globalVolumeLevel = volume.value;
        GlobalMouseSensitivity = mouseSns.value;
	}
    void StartGame()
    {
        if (doOnceLatch == false)
        {
            Debug.Log("gameStarted");
            animationController.Play();
            StartCoroutine(planeStop());
            startGame.gameObject.SetActive(false);
            options.gameObject.SetActive(false);
            quitGame.gameObject.SetActive(false);
            volume.gameObject.SetActive(false);
            mouseSns.gameObject.SetActive(false);
            optionsBG.gameObject.SetActive(false);
            StartCoroutine(nextLevel());
            doOnceLatch = true;
        }
    }
    void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
        
    }
    void GoToOptions()
    {
        onOptions = true;
        volume.gameObject.SetActive(true);
        mouseSns.gameObject.SetActive(true);
        optionsBG.gameObject.SetActive(true);
    }
    void optionsQuit()
    {
        onOptions = false;
        volume.gameObject.SetActive(false);
        mouseSns.gameObject.SetActive(false);
        optionsBG.gameObject.SetActive(false);

    }
    IEnumerator nextLevel()
    {
        
        yield return new WaitForSeconds(32);
        Debug.Log("gone to next level");
        SceneManager.LoadScene("Final Island V3");
    }
    IEnumerator planeStop()
    {
        yield return new WaitForSeconds(15);
        plane.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public int remainingTimeSet = 10;
    public int currentTime; 
    public Button connectButton;
    public Button timerButton;
    public Button playButton;
    public GameObject mainMenu;


    void Awake()
    {
        DontDestroyOnLoad (this.gameObject);
    }
    

    public void showTimerButton ()
    {
        Debug.Log("ShowTimerButton");
        timerButton.gameObject.SetActive(true);
    }

    public void showPlayButton()
    {
        connectButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    public void PlayGameButton()
    {
        SceneManager.LoadScene("BanksterTimer", LoadSceneMode.Single);
        Debug.Log("Start Spiel");
    }

    public void QuitGameButton()
    {
        Debug.Log("Beende Spiel");
        Application.Quit();
    }

    public void SetTimeButton ()
    {
        Debug.Log("Zeit einstellen");
    }

    public void tenSeconds()
    {
        remainingTimeSet = 10;
    }

    public void sixtySeconds ()
    {
        remainingTimeSet = 60;
    }

    public void onesixtySeconds ()
    {
        remainingTimeSet = 180; 
    }

    public void mainMenuDisable()
    {
        if (PhotonNetwork.room.PlayerCount > 0)
        {
            mainMenu.SetActive(false);
        }
    }
}

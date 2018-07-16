using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : Photon.MonoBehaviour , IPunObservable
{

    public Text timerText;
    public int timeRemaining; //set time from the start menu
    int timeLimit; //for the for loop the number of repetitions
    GameCondition endOfGameScript;


    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(timeRemaining);
        }

        else
        {
            this.timeRemaining = (int)stream.ReceiveNext();
        }
    }

    // Use this for initialization
    public void setTimer () {

        timeRemaining = GameObject.Find("GUIManager").GetComponent<MainMenuScript>().remainingTimeSet;
        
        Debug.Log(timeRemaining);
        timeLimit = timeRemaining; //number of repetitions need to be the same as the value put in timereamining at the beginning
        StartCoroutine(countdown());

        endOfGameScript = GameObject.Find("GameHandler").GetComponent<GameCondition>();
    }
	


    IEnumerator countdown ()
    {
        if (timeRemaining != 0) {

          for (int i = 0; i < timeLimit; i++ )
          {
              yield return new WaitForSeconds(1);
              timeRemaining -= 1;
              timerText.text = "Time: " + timeRemaining;

                if (timeRemaining == 0)
                {
                    if (endOfGameScript != null)
                    {
                        endOfGameScript.EndOfGame();
                    }
                }
          }
        }

    }
}

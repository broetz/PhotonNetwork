using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GUINetworkMenu : MonoBehaviour {

    //responsible for updating text and functions on buttons regarding the network

    public Text infoText;
    public Button connectButton;

   
    void Start () {
        connectButton.onClick.AddListener(startConnection);
    }
	

	void Update () {

        if (PhotonNetwork.connectionStateDetailed.ToString() != "Joined")
        {
            infoText.text = PhotonNetwork.connectionStateDetailed.ToString();
        }

        else
        {
            infoText.text = "Connected to" + PhotonNetwork.room.name + "Players online:" + PhotonNetwork.room.PlayerCount;
        }

    }

    void startConnection()
    {

        Debug.Log("Button clicked");

        if (!PhotonNetwork.connectedAndReady)
        {
            PhotonNetwork.ConnectUsingSettings("V0.1");
        }
        else
        {
            PhotonNetwork.Disconnect();
        }
    }
}

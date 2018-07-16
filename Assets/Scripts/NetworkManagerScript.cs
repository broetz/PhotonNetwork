using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerScript : MonoBehaviour {

    public Transform spawnPoint01;
    public Transform spawnPoint02;

    //das hier bei Jorni einfügen
    public bool master = false; 

	
	void Start () {
       
	}
	

	void Update () {


	}

    void OnConnectedToMaster()
    {
        Debug.Log("Connected with Master");
        PhotonNetwork.JoinLobby();
    }


    void OnJoinedLobby() {
        Debug.Log("Connected with Lobby");

        RoomOptions myRoomOptions = new RoomOptions();
        myRoomOptions.MaxPlayers = 2;

        PhotonNetwork.JoinOrCreateRoom("Room1", myRoomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom ()
    {
        Debug.Log("Connected with Room");


        if (PhotonNetwork.playerList.Length > 1)
        {
            StartCoroutine(SpawnPlayer02());
        }

        else
        {
            StartCoroutine(SpawnPlayer01());
        }


        // das hier bei jorni einfügen
        if (PhotonNetwork.room.PlayerCount == 1)
        {
            //master= true
            GameObject.Find("GUIManager").GetComponent<MainMenuScript>().showTimerButton();
            GameObject.Find("GUIManager").GetComponent<MainMenuScript>().showPlayButton();
        }

        else if (PhotonNetwork.room.PlayerCount > 1)
        {
            master = false;
            Debug.Log("Master false");
            GameObject.Find("GUIManager").GetComponent<MainMenuScript>().showPlayButton();
        }


    }

    //Spawns both player at the set spawn points
    IEnumerator SpawnPlayer01 ()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject myPlayer = PhotonNetwork.Instantiate("MyPlayer", spawnPoint01.position, Quaternion.identity, 0) as GameObject;
    }

    IEnumerator SpawnPlayer02()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject myPlayer = PhotonNetwork.Instantiate("MyPlayer", spawnPoint02.position, Quaternion.identity, 0) as GameObject;
    }
    
}

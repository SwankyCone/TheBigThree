using Photon.Pun;
using Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance;
    [SerializeField]string gameVersion;
    string connectionStatus;

    public int playerID;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        OnConnectToServer();
    }

    private void OnConnectToServer()
    {
       

        //Set the version of the game - only people of the same version can play together
        PhotonNetwork.GameVersion = gameVersion;

        //connect to the photon servers
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        connectionStatus = "Connected to master";
        PhotonNetwork.JoinLobby();

        connectionStatus = "Connecting to Lobby";
    }

    public override void OnJoinedLobby()
    {
        connectionStatus = "Lobby Joined";
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionStatus = "Failed to join room";
        PhotonNetwork.CreateRoom("New Room");
        connectionStatus = "Creating Room";
    }

    public override void OnJoinedRoom()
    {
        connectionStatus = "Room Joined";
        playerID = PhotonNetwork.PlayerList.Length - 1;
        connectionStatus = $"playerID : {playerID}";

        SpawnPlayer();

    }

    void SpawnPlayer()
    {
        PhotonNetwork.Instantiate("Player",Vector3.up, Quaternion.identity);
    }

    public void OnGUI()
    {
        GUILayout.Label(connectionStatus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

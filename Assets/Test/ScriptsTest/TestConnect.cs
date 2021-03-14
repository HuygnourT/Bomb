using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server.");
        PhotonNetwork.SendRate = 20;
        PhotonNetwork.SerializationRate = 5;
        PhotonNetwork.AutomaticallySyncScene = true; // When player join room created before , and in that room already start game, player can join dirrect in game
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
       
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon. ",this);
        Debug.Log("My nickname is " + PhotonNetwork.LocalPlayer.NickName,this);
        print(PhotonNetwork.LocalPlayer.NickName);

        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected server for reason "+cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        print("Joined lobby");
    }
}

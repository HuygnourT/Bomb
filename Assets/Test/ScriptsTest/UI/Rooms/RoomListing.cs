using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public RoomInfo RoomInfo { get; private set;}

    public void SetRoomInfo(RoomInfo roomInfo)
    {   
        text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
        RoomInfo = roomInfo;
    }

    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}

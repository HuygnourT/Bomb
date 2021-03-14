using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _conent;

    [SerializeField]
    private RoomListing _roomListings;

    private List<RoomListing> _listings = new List<RoomListing>();
    private RoomsCanvases roomCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        roomCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        roomCanvases.CurrentRoomCanvas.Show();
        _conent.DestroyChildren();
        _listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            else
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);

                if(index == -1)
                {
                    RoomListing listing = Instantiate(_roomListings, _conent);

                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        _listings.Add(listing);
                    }
                }
                else
                {
                    //Modify listing here
                }
                
                    
            }

        }
    }
}

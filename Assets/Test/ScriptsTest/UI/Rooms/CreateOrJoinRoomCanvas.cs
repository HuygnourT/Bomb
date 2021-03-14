using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu createRoomMenu;
    [SerializeField]
    private RoomListingsMenu roomListingsMenu;

    private RoomsCanvases roomCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        roomCanvases = canvases;
        createRoomMenu.FirstInitialize(canvases);
        roomListingsMenu.FirstInitialize(canvases);
    }
}

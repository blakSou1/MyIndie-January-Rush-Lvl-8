using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<Room> rooms = new();
    public List<RoomBase> roomsEntity = new();

    void Awake()
    {
        G.roomManager = this;

        Room roomPlayer = Framefork.AddRoom(typeof(RoomPlayer));

        roomPlayer.transform.SetParent(transform, false);

        rooms.Add(roomPlayer);
    }

}

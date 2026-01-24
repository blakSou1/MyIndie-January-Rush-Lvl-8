using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<Room> rooms = new();
    public List<RoomBase> roomsEntity = new();

    void Start()
    {
        G.roomManager = this;

        RoomPlayer roomPlayer = new();

        //rooms.Add(roomPlayer);
    }

}

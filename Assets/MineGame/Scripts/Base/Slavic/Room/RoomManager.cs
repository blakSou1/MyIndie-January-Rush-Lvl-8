using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<Room> rooms = new();
    public List<RoomBase> roomsEntity = new();

    public List<Transform> camera = new();

    [HideInInspector] public int indexCamera = 0;

    void Awake()
    {
        G.roomManager = this;

        AddRoom(typeof(RoomThorns));
        AddRoom(typeof(RoomThorns));
        AddRoom(typeof(RoomPlayer));


    }

    public void AddRoom(Type roomType)
    {
        Room room = Framefork.AddRoom(roomType);

        room.transform.SetParent(camera[indexCamera].transform, false);

        indexCamera++;

        rooms.Add(room);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<Room> rooms = new();
    public List<RoomBase> roomsEntity = new();

    [HideInInspector] public List<GameObject> camera = new();

    [HideInInspector] public int indexCamera = 0;

    void Awake()
    {
        camera = GameObject.FindGameObjectsWithTag("Respawn").ToList();

        G.roomManager = this;

        AddRoom(typeof(RoomThorns));
        AddRoom(typeof(RoomThorns));
        AddRoom(typeof(RoomPlayer));


    }

    public void AddRoom(Type roomType)
    {
        Room room = Framefork.AddRoom(roomType);

        indexCamera++;

        room.transform.SetParent(camera[indexCamera].transform, false);

        rooms.Add(room);
    }
}

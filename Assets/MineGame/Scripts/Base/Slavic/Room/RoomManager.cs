using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public List<Room> rooms = new();
    public List<RoomBase> roomsEntity = new();

    public List<Transform> camera = new();
    public List<Button> skilButton = new();

    [HideInInspector] public int indexCamera = 0;

    void Awake()
    {
        G.roomManager = this;
        foreach (var i in skilButton)
        {
            Image im = i.GetComponent<Image>();
            Color color = im.color;

            color.a = 0;
            im.color = color;
        }

        AddRoom(typeof(RoomThorns));
        AddRoom(typeof(RoomPlayer));
    }

    public void AddInsertRoom(Type roomType)
    {
        Room room = Framefork.AddRoom(roomType);

        int index = Mathf.Max(0, rooms.Count - 1);

        room.transform.SetParent(camera[index].transform, false);

        room.button = skilButton[index];

        SubscribeButtonToEvents(skilButton[index], room.events);

        indexCamera++;

        rooms.Insert(index, room);


        int indexPlayer = rooms.Count - 1;

        room = rooms[indexPlayer];

        room.transform.SetParent(camera[indexPlayer].transform, false);

        room.button = skilButton[indexPlayer];

        SubscribeButtonToEvents(skilButton[indexPlayer], room.events);
    }

    public void AddRoom(Type roomType)
    {
        Room room = Framefork.AddRoom(roomType);

        room.transform.SetParent(camera[indexCamera].transform, false);

        room.button = skilButton[indexCamera];

        SubscribeButtonToEvents(skilButton[indexCamera], room.events);

        indexCamera++;

        rooms.Add(room);
    }
    private void SubscribeButtonToEvents(Button button, List<UnityEvent> events = null)
    {
        if(events.Count > 0)
        {
            Image im = button.GetComponent<Image>();
            Color color = im.color;

            color.a = 1;
            im.color = color;
        }

        button.onClick.RemoveAllListeners();

        foreach (UnityEvent unityEvent in events)
        {
            if (unityEvent != null)
                button.onClick.AddListener(() => unityEvent.Invoke());
        }
    }
}

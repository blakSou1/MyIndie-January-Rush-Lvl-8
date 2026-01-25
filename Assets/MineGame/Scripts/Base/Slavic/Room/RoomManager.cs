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

        AddRoom(typeof(RoomThorns));
        AddRoom(typeof(RoomPoisonous));
        AddRoom(typeof(RoomThorns));
        AddRoom(typeof(RoomPlayer));
    }

    public void AddRoom(Type roomType)
    {
        Room room = Framefork.AddRoom(roomType);

        room.transform.SetParent(camera[indexCamera].transform, false);

        SubscribeButtonToEvents(skilButton[indexCamera], room.events);

        indexCamera++;

        rooms.Add(room);
    }
    private void SubscribeButtonToEvents(Button button, List<UnityEvent> events = null)//TODO делать кнопку невидимой если нет ивентов
    {
        button.onClick.RemoveAllListeners();

        foreach (UnityEvent unityEvent in events)
        {
            if (unityEvent != null)
                button.onClick.AddListener(() => unityEvent.Invoke());
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class RoomBase
{
    public Dictionary<Entity, Coroutine> ListAction = new();
    public Dictionary<Entity, Coroutine> ListPassiv = new();

    public Room model;

    public Room prefab;

    public RoomBase()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "name");
        G.roomManager.roomsEntity.Add(this);
    }

    public virtual void EnterEntity(Entity toClaim)
    {

    }

    public virtual void ExitEntity(Entity toClaim)
    {

    }

    public virtual void ActivSkil()
    {

    }
    public virtual void DeActivSkil()
    {

    }

}

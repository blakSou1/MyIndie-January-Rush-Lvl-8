using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public static class Framefork
{
    public static T Load<T>(this string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public static Room AddRoom(Type type)
    {
        var basicEntity = FindInheritedFrom(G.roomManager.roomsEntity, type.GetType());

        basicEntity ??= Activator.CreateInstance(type) as RoomBase;

        var state = new RoomeState
        {
            model = basicEntity
        };

        if (basicEntity == null) Debug.Log("not basic entity");

        var instance = GameObject.Instantiate(basicEntity.prefab);
        instance.SetState(state);
        return instance;
    }

    public static RoomBase FindInheritedFrom(List<RoomBase> list, Type type)
    {
        foreach (var item in list)
        {
            if (item.GetType() == type)
                return item;
        }
        return null;
    }

    public static Entity AddEntity(Type type)
    {
        var basicEntity = FindInheritedFrom(G.run.entity, type.GetType());

        basicEntity ??= Activator.CreateInstance(type) as EnemiesBase;

        var state = new EntityState
        {
            model = basicEntity
        };

        var instance = GameObject.Instantiate(basicEntity.prefab);
        instance.SetState(state);
        return instance;
    }

    public static EnemiesBase FindInheritedFrom(List<EnemiesBase> list, Type type)
    {
        foreach (var item in list)
        {
            if (item.GetType() == type)
                return item;
        }
        return null;
    }
}

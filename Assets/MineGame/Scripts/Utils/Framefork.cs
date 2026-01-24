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

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomeState
{
    public RoomBase model;
}

public class Room : MonoBehaviour
{
    public List<Entity> objects = new();

    public List<UnityEvent> events;

    public Transform startPos;
    public Transform endPos;

    public RoomeState state;

    public void SetState(RoomeState room)
    {
        state = room;
        state.model.model = this;
    }

    public void AddEntity(Entity toClaim)
    {
        if (toClaim.state.room != null)
            toClaim.state.room.Release(toClaim);

        toClaim.state.room = this;
        objects.Add(toClaim);

        toClaim.transform.SetParent(transform, false);
        toClaim.transform.SetSiblingIndex(3);

        toClaim.transform.position = startPos.position;

        state.model.EnterEntity(toClaim);
    }

    public void ActivationSkill()
    {
        state.model.ActivSkil();//TODO время востановления скила + визуальная обвязка
    }

    public void Release(Entity toClaim)
    {
        if (objects.Contains(toClaim))
        {
            objects.Remove(toClaim);
            state.model.ExitEntity(toClaim);
        }
    }

}

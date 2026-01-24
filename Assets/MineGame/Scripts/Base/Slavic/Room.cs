using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<Entity> objects = new();

    public Transform startPos;
    public Transform endPos;

    public void AddEntity(Entity toClaim)
    {
        if (toClaim.state.room != null)
            toClaim.state.room.Release(toClaim);

        toClaim.state.room = this;

        toClaim.transform.position = startPos.position;

        StartCoroutine(toClaim.state.moveable.Move(endPos.position));
    }
    public void Release(Entity toClaim)
    {
        if (objects.Contains(toClaim))
            objects.Remove(toClaim);
    }
}

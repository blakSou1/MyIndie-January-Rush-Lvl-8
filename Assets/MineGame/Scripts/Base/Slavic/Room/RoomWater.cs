using System.Collections;
using UnityEngine;

public class RoomWater : RoomBase
{
    bool isSkill = false;

    public RoomWater()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomWater");
        G.roomManager.roomsEntity.Add(this);
    }

    public override void EnterEntity(Entity toClaim)
    {
        toClaim.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));

        if (isSkill)
        {
            var corutine = model.StartCoroutine(UnigilSpeed(toClaim));

            ListAction.Add(toClaim, corutine);
        }

    }

    public override void ActivSkil()
    {
        isSkill = true;

        foreach (var a in model.objects)
        {
            var corutine = model.StartCoroutine(UnigilSpeed(a));

            if (!ListAction.ContainsKey(a))
                ListAction.Add(a, corutine);
        }
    }
    public override void DeActivSkil()
    {
        isSkill = false;

        ListAction.Clear();
    }

    private IEnumerator UnigilSpeed(Entity toClaim)
    {
        float speed = toClaim.state.moveable.maxVelocity;

        toClaim.state.moveable.maxVelocity = 30;

        toClaim.StopAllCoroutines();

        yield return toClaim.StartCoroutine(toClaim.state.moveable.MoveV(prefab.startPos.position));

        toClaim.state.moveable.maxVelocity = speed;

        toClaim.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));
        ListAction.Remove(toClaim);
    }
}

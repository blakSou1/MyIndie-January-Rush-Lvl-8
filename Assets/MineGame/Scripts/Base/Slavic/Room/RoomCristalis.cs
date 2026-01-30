using System.Collections;
using UnityEngine;

public class RoomCristalis : RoomBase
{
    bool isSkill = false;

    public RoomCristalis()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomCristalis");
        G.roomManager.roomsEntity.Add(this);
    }

    public override void EnterEntity(Entity toClaim)
    {
        toClaim.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));

        var corutine = G.roomManager.StartCoroutine(NouSpeed(toClaim));
        ListPassiv.Add(toClaim, corutine);

        if (isSkill)
        {
            corutine = model.StartCoroutine(UnigilSpeed(toClaim));
            ListAction.Add(toClaim, corutine);
        }

    }

    public override void ExitEntity(Entity toClaim)
    {
        while (ListAction.TryGetValue(toClaim, out Coroutine cor))
        {
            G.roomManager.StopCoroutine(cor);

            ListAction.Remove(toClaim);
        }
        while (ListPassiv.TryGetValue(toClaim, out Coroutine cor))
        {
            G.roomManager.StopCoroutine(cor);
            toClaim.state.moveable.maxVelocity += 5;

            ListPassiv.Remove(toClaim);
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
    }

    private IEnumerator NouSpeed(Entity toClaim)
    {
        yield return null;

        toClaim.state.moveable.maxVelocity -= 5;
    }

    private IEnumerator UnigilSpeed(Entity toClaim)
    {
        float speed = toClaim.state.moveable.maxVelocity;

        yield return null;

        toClaim.state.moveable.maxVelocity = 0;

        yield return new WaitForSeconds(4f);

        toClaim.state.moveable.maxVelocity = speed;

        ListAction.Remove(toClaim);
    }
}

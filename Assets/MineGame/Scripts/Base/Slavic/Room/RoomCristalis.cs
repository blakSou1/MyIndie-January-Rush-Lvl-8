using System.Collections;
using UnityEngine;

public class RoomCristalis : RoomBase
{
    public RoomCristalis()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomCristalis");
        G.roomManager.roomsEntity.Add(this);
    }

    public override void EnterEntity(Entity toClaim)
    {
        toClaim.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));

        var corutine = G.roomManager.StartCoroutine(DamageEntityPoisonous(toClaim));
        ListAction.Add(toClaim, corutine);
    }

    public override void ExitEntity(Entity toClaim)
    {
        if(ListAction.TryGetValue(toClaim, out Coroutine cor))
        {
            G.roomManager.StopCoroutine(cor);
            toClaim.state.moveable.maxVelocity += 5;

            ListAction.Remove(toClaim);
        }
    }

    public override void ActivSkil()
    {
        foreach (var a in model.objects)
        {
            var corutine = model.StartCoroutine(DamageEntity(a));

            if (!ListAction.ContainsKey(a))
                ListAction.Add(a, corutine);
        }
    }

    private IEnumerator DamageEntityPoisonous(Entity toClaim)
    {
        yield return null;

        toClaim.state.moveable.maxVelocity -= 5;
    }

    private IEnumerator DamageEntity(Entity toClaim)
    {
        float speed = toClaim.state.moveable.maxVelocity;

        yield return null;

        toClaim.state.moveable.maxVelocity = 0;

        yield return new WaitForSeconds(4f);

        toClaim.state.moveable.maxVelocity = speed;

        ListAction.Remove(toClaim);
    }
}

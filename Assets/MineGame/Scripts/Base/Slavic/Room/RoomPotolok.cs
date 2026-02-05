using System.Collections;
using UnityEngine;

public class RoomPotolok : RoomBase
{
    int damage = 8;

    public RoomPotolok()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomPotolok");
        G.roomManager.roomsEntity.Add(this);
    }

    public override void EnterEntity(Entity toClaim)
    {
        toClaim.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));
    }

    public override void ActivSkil()
    {
        model.StartCoroutine(DamageEntity());
    }

    private IEnumerator DamageEntity()
    {
        yield return null;

        foreach (var i in model.objects)
            i.state.health.Damage(damage);
        yield return new WaitForSeconds(.8f);

        foreach (var i in model.objects)
            i.state.health.Damage(damage);
        yield return new WaitForSeconds(.8f);

        foreach (var i in model.objects)
            i.state.health.Damage(damage);

    }
}

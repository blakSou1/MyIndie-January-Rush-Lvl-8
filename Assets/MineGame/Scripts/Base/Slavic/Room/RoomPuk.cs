using System.Collections;

public class RoomPuk : RoomBase
{
    int damage = 18;

    public RoomPuk()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomPuk");
        G.roomManager.roomsEntity.Add(this);
        isRigth = true;

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
    }
}

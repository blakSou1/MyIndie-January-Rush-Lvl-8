using System.Collections;
using System.Security.Claims;
using UnityEngine;

public class RoomThorns : RoomBase
{
    int damage = 1;

    bool isSkill = false;

    public RoomThorns()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomThorns");
        G.roomManager.roomsEntity.Add(this);
    }

    public override void EnterEntity(Entity toClaim)
    {
        toClaim.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));
    }
    public override void ExitEntity(Entity toClaim)
    {
        if (ListAction.ContainsKey(toClaim))
            ListAction.Remove(toClaim);
    }

    public override void ActivSkil()
    {
        isSkill = true;

        model.StartCoroutine(DamageEntity());
    }
    public override void DeActivSkil()
    {
        isSkill = false;

        ListAction.Clear();
    }

    private IEnumerator DamageEntity()
    {
        yield return null;

        while (isSkill)
        {
            foreach (var a in model.objects)
                a.state.health.Damage(damage);

            yield return new WaitForSeconds(.3f);
        }
    }
}

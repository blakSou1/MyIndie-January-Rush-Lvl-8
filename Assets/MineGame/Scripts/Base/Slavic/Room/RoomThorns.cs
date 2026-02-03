using System.Collections;
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

        if (isSkill)
        {
            var corutine = model.StartCoroutine(DamageEntity(toClaim));
            ListAction.Add(toClaim, corutine);
        }

    }

    public override void ActivSkil()
    {
        isSkill = true;

        foreach (var a in model.objects)
        {
            var corutine = model.StartCoroutine(DamageEntity(a));
            
            ListAction.Add(a, corutine);
        }
    }
    public override void DeActivSkil()
    {
        isSkill = false;

        ListAction.Clear();
    }

    private IEnumerator DamageEntity(Entity toClaim)
    {
        yield return null;

        while (isSkill && toClaim.state.health.currentHealth > 0)
        {
            toClaim.state.health.Damage(damage);
            yield return new WaitForSeconds(.3f);
        }
    }
}

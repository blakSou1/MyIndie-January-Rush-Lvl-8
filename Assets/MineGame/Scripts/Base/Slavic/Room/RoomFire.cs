using System.Collections;
using UnityEngine;

public class RoomFire : RoomBase
{
    int damage = 4;
    bool isSkill = false;

    public RoomFire()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomFire");
        G.roomManager.roomsEntity.Add(this);
    }

    public override void EnterEntity(Entity toClaim)
    {
        toClaim.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));

        if (isSkill)
        {
            var corutine = model.StartCoroutine(DamageEntityPoisonous(toClaim));
            ListAction.Add(toClaim, corutine);
        }

    }

    public override void ExitEntity(Entity toClaim)
    {
        if(ListAction.TryGetValue(toClaim, out Coroutine cor))
        {
            G.roomManager.StopCoroutine(cor);
            ListAction.Remove(toClaim);
        }
    }

    public override void ActivSkil()
    {
        isSkill = true;

        foreach (var a in model.objects)
        {
            var corutine = model.StartCoroutine(DamageEntityPoisonous(a));

            if (!ListAction.ContainsKey(a))
                ListAction.Add(a, corutine);
        }
    }
    public override void DeActivSkil()
    {
        isSkill = false;
    }

    private IEnumerator DamageEntityPoisonous(Entity toClaim)
    {
        yield return null;

        while (toClaim != null)
        {
            toClaim.state.health.Damage(damage+2);
            yield return new WaitForSeconds(.3f);
        }

        ListAction.Remove(toClaim);
    }
}

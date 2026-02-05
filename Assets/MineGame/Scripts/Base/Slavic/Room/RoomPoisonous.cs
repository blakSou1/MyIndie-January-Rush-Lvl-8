using System.Collections;
using UnityEngine;

public class RoomPoisonous : RoomBase
{
    float damage = .7f;
    bool isSkill = false;

    public RoomPoisonous()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomPoisonous");
        G.roomManager.roomsEntity.Add(this);
    }

    public override void EnterEntity(Entity toClaim)
    {
        toClaim.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));

        var corutine = G.roomManager.StartCoroutine(DamageEntityPassiv(toClaim));
        ListPassiv.Add(toClaim, corutine);

        if (isSkill)
        {
            corutine = model.StartCoroutine(DamageEntityPoisonous(toClaim));

            ListAction.Add(toClaim, corutine);
        }
    }

    public override void ExitEntity(Entity toClaim)
    {
        if (ListPassiv.TryGetValue(toClaim, out Coroutine cor))
        {
            G.roomManager.StopCoroutine(cor);
            ListPassiv.Remove(toClaim);
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

        ListAction.Clear();
    }

    private IEnumerator DamageEntityPoisonous(Entity toClaim)
    {
        yield return null;

        while (toClaim.state.health.currentHealth > 0)
        {
            toClaim.state.health.Damage((float)damage * 0.8f);
            yield return new WaitForSeconds(.6f);
        }
    }

    private IEnumerator DamageEntityPassiv(Entity toClaim)
    {
        yield return null;

        while (ListPassiv.ContainsKey(toClaim) && toClaim.state.health.currentHealth > 0)
        {
            toClaim.state.health.Damage(damage);
            yield return new WaitForSeconds(.5f);
        }

        ListPassiv.Remove(toClaim);
    }
}

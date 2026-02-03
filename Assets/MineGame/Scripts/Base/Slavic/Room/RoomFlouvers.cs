using System.Collections;
using UnityEngine;

public class RoomFlouvers : RoomBase
{
    bool isSkill = false;
    float damage = .4f;

    public RoomFlouvers()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomFlouvers");
        G.roomManager.roomsEntity.Add(this);
        isRigth = true;
    }

    public override void EnterEntity(Entity toClaim)
    {
        toClaim.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));

        var corutine = G.roomManager.StartCoroutine(DamageEntityPassiv(toClaim));
        ListPassiv.Add(toClaim, corutine);

        if (isSkill)
        {
            corutine = model.StartCoroutine(UnigilSpeed(toClaim));

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
            var corutine = model.StartCoroutine(UnigilSpeed(a));

            ListAction.Add(a, corutine);
        }
    }
    public override void DeActivSkil()
    {
        isSkill = false;

        ListAction.Clear();
    }

    private IEnumerator DamageEntityPassiv(Entity toClaim)
    {
        yield return null;

        while (ListPassiv.ContainsKey(toClaim) && toClaim.state.health.currentHealth > 0)
        {
            toClaim.state.health.Damage(damage);
            yield return new WaitForSeconds(.3f);
        }

        ListPassiv.Remove(toClaim);
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

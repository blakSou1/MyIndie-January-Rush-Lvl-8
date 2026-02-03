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
        isRigth = true;
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

    public override void ActivSkil()
    {
        isSkill = true;

        foreach (var a in model.objects)
        {
            var corutine = model.StartCoroutine(DamageEntityPoisonous(a));

            ListAction.Add(a, corutine);
        }
    }
    public override void DeActivSkil()
    {
        Debug.Log(2222);

        isSkill = false;

        ListAction.Clear();
    }

    private IEnumerator DamageEntityPoisonous(Entity toClaim)
    {
        while (isSkill && toClaim.state.health.currentHealth > 0)
        {
            Debug.Log(111);
            toClaim.state.health.Damage(damage);
            yield return new WaitForSeconds(.3f);
        }
        Debug.Log(444);

        ListAction.Remove(toClaim);
    }
}

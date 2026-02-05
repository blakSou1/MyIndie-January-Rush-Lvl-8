using System.Collections;
using System.Security.Claims;
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
    }
    public override void ExitEntity(Entity toClaim)
    {
        if (ListAction.ContainsKey(toClaim))
            ListAction.Remove(toClaim);
    }

    public override void ActivSkil()
    {
        isSkill = true;

        model.StartCoroutine(DamageEntityPoisonous());
    }
    public override void DeActivSkil()
    {
        isSkill = false;

        ListAction.Clear();
    }

    private IEnumerator DamageEntityPoisonous()
    {
        while (isSkill)
        {
            foreach (var a in model.objects)
                a.state.health.Damage(damage);

            yield return new WaitForSeconds(.3f);
        }
    }
}

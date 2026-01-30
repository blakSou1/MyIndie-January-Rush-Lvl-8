using System.Collections;
using System.Security.Claims;
using UnityEngine;

public class RoomThorns : RoomBase
{
    int damage = 1;

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
        if (ListAction.TryGetValue(toClaim, out Coroutine cor))
        {
            G.roomManager.StopCoroutine(cor);
            ListAction.Remove(toClaim);
        }
    }

    public override void ActivSkil()
    {
        foreach (var a in model.objects)
        {
            var corutine = model.StartCoroutine(DamageEntity(a));
            
            if(!ListAction.ContainsKey(a))
                ListAction.Add(a, corutine);

        }
    }

    private IEnumerator DamageEntity(Entity toClaim)
    {
        yield return null;

        while (ListAction.ContainsKey(toClaim) && toClaim.state.health.currentHealth > 0)
        {
            toClaim.state.health.Damage(damage);
            yield return new WaitForSeconds(.3f);
        }

        ListAction.Remove(toClaim);
    }
}

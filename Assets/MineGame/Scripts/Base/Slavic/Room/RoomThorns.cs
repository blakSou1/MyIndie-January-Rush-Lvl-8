using System.Collections;
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
        G.roomManager.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));

        var corutine = G.roomManager.StartCoroutine(DamageEntity(toClaim));
        ListAction.Add(toClaim, corutine);
    }

    public override void ExitEntity(Entity toClaim)
    {
        if(ListAction.TryGetValue(toClaim, out Coroutine cor))
        {
            G.roomManager.StopCoroutine(cor);
            ListAction.Remove(toClaim);
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
    }
}

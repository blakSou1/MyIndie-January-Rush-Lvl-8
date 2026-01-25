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
    }

    public override void ActivSkil()
    {
        foreach (var a in model.objects)
        {
            //TODO animation активации скила пики из пола 
            DamageEntity(a);
        }
    }

    private void DamageEntity(Entity toClaim)
    {
        Debug.Log("SkillUsed");
        toClaim.state.health.Damage(damage);
    }
}

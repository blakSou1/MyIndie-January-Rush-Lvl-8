using UnityEngine;

public class RoomPlayer : RoomBase
{
    public RoomPlayer()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomPlayer");
        G.roomManager.roomsEntity.Add(this);
    }

    public override void EnterEntity(Entity toClaim)
    {
        toClaim.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));
    }
    public override void ExitEntity(Entity toClaim)
    {
        Debug.Log("ddd");
        G.loss.Louse();
    }

}

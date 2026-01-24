
public class RoomThorns : RoomBase
{
    public RoomThorns()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomThorns");
        G.roomManager.roomsEntity.Add(this);
    }

    public override void EnterEntity(Entity toClaim)
    {
        G.roomManager.StartCoroutine(toClaim.state.moveable.Move(prefab.endPos.position));
    }
}


public class RoomPlayer : RoomBase
{
    public RoomPlayer()
    {
        prefab = Framefork.Load<Room>("prefabRoom/" + "RoomPlayer");
        G.roomManager.roomsEntity.Add(this);
    }

    public override void EnterEntity(Entity toClaim)
    {
        //TODO Game over
    }

}

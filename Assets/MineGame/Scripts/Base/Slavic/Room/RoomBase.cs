
public class RoomBase
{
    public Room prefab;

    public RoomBase()
    {
        prefab = Framefork.Load<Room>("prefab/" + "name");
        G.roomManager.roomsEntity.Add(this);
    }

    public virtual void EnterEntity(Entity toClaim)
    {

    }

    public virtual void ExitEntity(Entity toClaim)
    {

    }

}

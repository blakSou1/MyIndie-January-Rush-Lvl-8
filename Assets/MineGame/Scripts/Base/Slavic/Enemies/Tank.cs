
public class Tank : EnemiesBase
{

    public Tank()
    {
        prefab = Framefork.Load<Entity>("prefab/" + "Tank");
        G.run.entity.Add(this);
    }

}

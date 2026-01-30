
public class Boss : EnemiesBase
{

    public Boss()
    {
        prefab = Framefork.Load<Entity>("prefab/" + "Boss");
        G.run.entity.Add(this);
    }

}

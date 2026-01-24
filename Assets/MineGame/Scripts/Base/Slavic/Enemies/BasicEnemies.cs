
public class BasicEnemies : EnemiesBase
{

    public BasicEnemies()
    {
        prefab = Framefork.Load<Entity>("prefab/" + "Humanoid");
        G.run.entity.Add(this);
    }

}

public abstract class EnemiesBase
{
    public Entity prefab;

    public EnemiesBase()
    {
        prefab = Framefork.Load<Entity>("prefab/" + "name");
        G.run.entity.Add(this);
    }
}


public class HumanoidOrange : EnemiesBase
{

    public HumanoidOrange()
    {
        prefab = Framefork.Load<Entity>("prefab/" + "HumanoidOrange");
        G.run.entity.Add(this);
    }

}


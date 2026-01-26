
public class HumanoidBlue : EnemiesBase
{

    public HumanoidBlue()
    {
        prefab = Framefork.Load<Entity>("prefab/" + "HumanoidBlue");
        G.run.entity.Add(this);
    }

}

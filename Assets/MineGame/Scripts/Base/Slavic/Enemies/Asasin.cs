
public class Asasin : EnemiesBase
{

    public Asasin()
    {
        prefab = Framefork.Load<Entity>("prefab/" + "Asasin");
        G.run.entity.Add(this);
    }

}

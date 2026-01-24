using UnityEngine;

public class EntityState
{
    public EnemiesBase model;
    public Entity view;
}

public class Entity : MonoBehaviour
{
    public EntityState state;

    public void SetState(EntityState entityState)
    {
        state = entityState;
        state.view = this;

    }
}

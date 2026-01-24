using UnityEngine;

public class EntityState
{
    public EnemiesBase model;
    public Entity view;

    public MoveableBase moveable;

    public Room room;
}

public class Entity : MonoBehaviour
{
    public EntityState state;

    public void SetState(EntityState entityState)
    {
        state = entityState;
        state.view = this;

        state.moveable = GetComponent<MoveableBase>();
    }
}

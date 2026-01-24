using UnityEngine;

public class GameMode : MonoBehaviour
{
    void Start()
    {
        Entity entity = Framefork.AddEntity(typeof(BasicEnemies));

        entity.transform.SetParent(G.roomManager.rooms[0].transform, false);

        G.roomManager.rooms[0].AddEntity(entity);
    }

    
}

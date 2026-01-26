using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    int coroutine = 0;
    List<GameObject> enemy = new();

    private void Awake()
    {
        G.spawnerController = this;
    }

    public void StartSpawmWave(Wave wave)
    {
        foreach(var i in wave.mobs)
            StartCoroutine(SpawnMobs(i));
    }
    private IEnumerator SpawnMobs(Mobs mobs)
    {
        if (mobs.spawnInterval > 0)
            StartCoroutine(SpawnInterval(mobs));
        else if (mobs.spawnDuration > 0)
            StartCoroutine(SpawnDuration(mobs));

        while (coroutine > 0)
            yield return new WaitForSeconds(.2f);

        while (IsEnemyListCompletelyEmpty())
            yield return new WaitForSeconds(.2f);

        G.gameMode.NextWaveChoice();
    }

    private IEnumerator SpawnInterval(Mobs mobs)
    {
        coroutine++;

        int count = 0;

        yield return new WaitForSeconds(mobs.startSpawnTime);

        while (count < mobs.count)
        {
            count++;

            Entity entity = Framefork.AddEntity(mobs.type);

            entity.transform.SetParent(G.roomManager.rooms[0].transform, false);

            enemy.Add(entity.gameObject);

            G.roomManager.rooms[0].AddEntity(entity);

            yield return new WaitForSeconds(mobs.spawnInterval);
        }

        coroutine--;
    }
    private IEnumerator SpawnDuration(Mobs mobs)
    {
        coroutine++;

        int count = 0;
        float spawnInterval = mobs.spawnDuration / mobs.count;

        yield return new WaitForSeconds(mobs.startSpawnTime);

        while (count < mobs.count)
        {
            count++;

            Entity entity = Framefork.AddEntity(mobs.type);

            entity.transform.SetParent(G.roomManager.rooms[0].transform, false);

            enemy.Add(entity.gameObject);

            G.roomManager.rooms[0].AddEntity(entity);

            yield return new WaitForSeconds(spawnInterval);
        }

        coroutine--;
    }
    public bool IsEnemyListCompletelyEmpty()
    {
        enemy.RemoveAll(e => e == null);

        if (enemy.Count != 0)
            return true;

        return false;
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : Wave
{
    public Wave1()
    {
        Mobs mob = new()
        {
            type = typeof(BasicEnemies),
            count = 3,
            startSpawnTime = 3f,
            spawnDuration = 6f,
        };

        reward = new()
        {
            typeof(RoomPoisonous), typeof(RoomPoisonous), typeof(RoomThorns)
        };

        mobs.Add(mob);
    }
}

public class Wave2 : Wave
{
    public Wave2()
    {
        Mobs mob = new()
        {
            type = typeof(BasicEnemies),
            count = 5,
            startSpawnTime = 2f,
            spawnDuration = 8f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(HumanoidBlue),
            count = 3,
            startSpawnTime = 4.5f,
            spawnInterval = 2.7f,
        };
        mobs.Add(mob);

    }
}

public class Wave
{
    public List<Mobs> mobs = new();

    public int numberWave;

    public List<Type> reward;
}

[Serializable]
public class Mobs
{
    public Type type;

    public int count;

    public float startSpawnTime;

    [Header("интервал между спавном моба")]
    public float spawnInterval;

    [Header("если > 0 - распределить спавн равномерно в течение этого времени")]
    public float spawnDuration;
}

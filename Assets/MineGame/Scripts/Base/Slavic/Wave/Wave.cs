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
            typeof(RoomPoisonous), typeof(RoomFire), typeof(RoomThorns)
        };

        mobs.Add(mob);
    }
}

public class Wave2 : Wave
{
    public Wave2()
    {
        reward = new()
        {
            typeof(RoomFire), typeof(RoomThorns), typeof(RoomFlouvers)
        };

        Mobs mob = new()
        {
            type = typeof(BasicEnemies),
            count = 5,
            startSpawnTime = 2f,
            spawnDuration = 12f,
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

public class Wave3 : Wave
{
    public Wave3()
    {
        reward = new()
        {
            typeof(RoomPoisonous), typeof(RoomCristalis), typeof(RoomFire)
        };

        Mobs mob = new()
        {
            type = typeof(HumanoidBlue),
            count = 14,
            startSpawnTime = 1f,
            spawnDuration = 17f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Asasin),
            count = 4,
            startSpawnTime = 4.5f,
            spawnInterval = 3.7f,
        };
        mobs.Add(mob);

    }
}

public class Wave4 : Wave
{
    public Wave4()
    {
        reward = new()
        {
            typeof(RoomFire), typeof(RoomCristalis), typeof(RoomPuk)
        };

        Mobs mob = new()
        {
            type = typeof(BasicEnemies),
            count = 14,
            startSpawnTime = 2f,
            spawnDuration = 12f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Asasin),
            count = 4,
            startSpawnTime = 4.5f,
            spawnInterval = 3.7f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Tank),
            count = 1,
            startSpawnTime = 7f,
            spawnInterval = 1f,
        };
        mobs.Add(mob);

    }
}

public class Wave5 : Wave
{
    public Wave5()
    {
        Mobs mob = new()
        {
            type = typeof(BasicEnemies),
            count = 6,
            startSpawnTime = 2f,
            spawnInterval = 2f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Asasin),
            count = 4,
            startSpawnTime = 4.5f,
            spawnInterval = 3.7f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Tank),
            count = 3,
            startSpawnTime = 7f,
            spawnInterval = 4f,
        };
        mob = new()
        {
            type = typeof(Boss),
            count = 1,
            startSpawnTime = 12f,
            spawnInterval = 1f,
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

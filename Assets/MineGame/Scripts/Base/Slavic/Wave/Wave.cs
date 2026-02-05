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
            startSpawnTime = 2f,
            spawnDuration = 6f,
        };

        reward = new()
        {
            typeof(RoomPoisonous), typeof(RoomFire), typeof(RoomPotolok)
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
            count = 9,
            startSpawnTime = 2f,
            spawnDuration = 22f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(HumanoidBlue),
            count = 3,
            startSpawnTime = 4.5f,
            spawnInterval = 3.7f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(HumanoidBlue),
            count = 3,
            startSpawnTime = 5.5f,
            spawnInterval = 4.7f,
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
            typeof(RoomPoisonous), typeof(RoomWater), typeof(RoomFire)
        };

        Mobs mob = new()
        {
            type = typeof(HumanoidBlue),
            count = 14,
            startSpawnTime = 1f,
            spawnDuration = 27f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(HumanoidBlue),
            count = 8,
            startSpawnTime = 8f,
            spawnDuration = 11f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(HumanoidOrange),
            count = 4,
            startSpawnTime = 3f,
            spawnDuration = 18f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Asasin),
            count = 4,
            startSpawnTime = 4.5f,
            spawnInterval = 4.7f,
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
            spawnDuration = 19f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Asasin),
            count = 4,
            startSpawnTime = 4.5f,
            spawnInterval = 4.7f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Tank),
            count = 1,
            startSpawnTime = 13f,
            spawnInterval = 1f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Tank),
            count = 2,
            startSpawnTime = 19f,
            spawnInterval = 8f,
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
            type = typeof(HumanoidBlue),
            count = 6,
            startSpawnTime = 2f,
            spawnInterval = 2f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Asasin),
            count = 8,
            startSpawnTime = 4.5f,
            spawnInterval = 3.7f,
        };
        mobs.Add(mob);

        mob = new()
        {
            type = typeof(Tank),
            count = 5,
            startSpawnTime = 7f,
            spawnInterval = 4f,
        };
        mob = new()
        {
            type = typeof(Boss),
            count = 1,
            startSpawnTime = 19f,
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

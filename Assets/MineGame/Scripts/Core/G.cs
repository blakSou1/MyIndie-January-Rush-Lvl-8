using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class G
{
    [Header("Fade settings")]
    public static bool showFading = true;
    [Header("Localization settings")]
    public static bool showLocOnStart = true;
    public static bool RewriteLocWithRus = false;

    public static bool IsPaused = false;

    public static LocSystem LocSystem;
    public static AudioManager AudioManager;
    public static SceneLoader SceneLoader;
    public static PausePanel pausePanel;

    public static Inpyts inputs;

    public static RunState run = new();

    //Объекты в игре
    public static Volume volume;
    public static Loss loss;
    public static RoomManager roomManager;
    public static GameMode gameMode;
    public static Choice choice;
    public static SpawnerController spawnerController;


}

public class ManagedBehaviour : MonoBehaviour
{
    void Update()
    {
        if (!G.IsPaused)
            PausableUpdate();
    }

    protected virtual void PausableUpdate()
    {
    }

    void FixedUpdate()
    {
        if (!G.IsPaused)
            PausableFixedUpdate();
    }

    protected virtual void PausableFixedUpdate()
    {
    }
}

public class RunState
{
    public int level;
    public int drawSize = 3;
    public int health = 10;
    public int maxHealth = 10;

    public List<EnemiesBase> entity = new();
}
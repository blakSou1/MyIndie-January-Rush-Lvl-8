using UnityEngine;

public class GameMode : MonoBehaviour
{
    int indexWave = 0;
    Wave wave;

    private void Awake()
    {
        G.gameMode = this;
    }

    void Start()
    {
        NextWave();
    }

    public void NextWave()
    {
        indexWave++;

        switch (indexWave)
        {
            case 1:
                wave = new Wave1();
                G.spawnerController.StartSpawmWave(wave);
                break;
            case 2:
                wave = new Wave2();
                G.spawnerController.StartSpawmWave(wave);
                break;


        }
    }
    public void NextWaveChoice()
    {
        if (indexWave != 0)
            G.choice.ChoiceIn(wave.reward[0], wave.reward[1], wave.reward[2]);
    }

}

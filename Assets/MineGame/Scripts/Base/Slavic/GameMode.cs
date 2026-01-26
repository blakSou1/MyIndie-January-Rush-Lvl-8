
using DG.Tweening;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    int indexWave = 0;
    [SerializeField]private GameObject _castle;
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
        if(indexWave <= 4)
        {
            Sequence sequence = DOTween.Sequence();
            sequence
            .Append(Camera.main.transform.DORotate(new Vector3(0, 90, 0), 1))
            .Append(_castle.transform.DOMoveY(-4f+indexWave, 2))
            .Append(Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1));
        }
        

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

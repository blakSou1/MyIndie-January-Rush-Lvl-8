using DG.Tweening;
using System.Collections;
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
        StartCoroutine(G.gameMode.NextWave());
    }

    public IEnumerator NextWave()
    {
        indexWave++;

        yield return StartCoroutine(PlayWaveAnimation());
        
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
            case 3:
                wave = new Wave3();
                G.spawnerController.StartSpawmWave(wave);
                break;
            case 4:
                wave = new Wave4();
                G.spawnerController.StartSpawmWave(wave);
                break;


        }
    }
    public void NextWaveChoice()
    {
        if (indexWave != 0 && wave.reward[0] != null)
            G.choice.ChoiceIn(wave.reward[0], wave.reward[1], wave.reward[2]);
    }

    public IEnumerator PlayWaveAnimation()
    {
        if (indexWave <= 4)
        {
            G.AudioManager.PlaySound(R.Audio.bah, .5f);

            //Camera.main.transform.DOKill(false);
            //_castle.transform.DOKill(false);

            Sequence sequence = DOTween.Sequence();

            sequence
                .Append(Camera.main.transform.DORotate(new Vector3(0, 90, 0), 1))
                .Append(_castle.transform.DOMoveY(-4f + indexWave, 2))
                .Append(Camera.main.transform.DORotate(new Vector3(0, 0, 0), 1));

            yield return sequence.WaitForCompletion();
        }
        else
        {
            G.loss.Win();
            yield return null;
        }
    }

}

using System.Collections;
using UnityEngine;

public class Loss : MonoBehaviour
{
    public CanvasGroup groupLoss;
    public CanvasGroup groupWin;

    bool isLoss = false;

    void Start()
    {
        G.loss = this;
        StartCoroutine(CanvasGroupHide(0, 0, groupLoss, 0));
        StartCoroutine(CanvasGroupHide(0, 0, groupWin, 0));
    }

    public void Louse()
    {
        if (isLoss) return;

        isLoss = true;

        G.AudioManager.PlaySound(R.Audio.Louse, .5f);

        StartCoroutine(CanvasGroupHide(0, 1, groupLoss, .4f));
    }
    public void Win()
    {
        if (isLoss) return;

        isLoss = true;

        G.AudioManager.PlaySound(R.Audio.Louse, 1.5f);

        StartCoroutine(CanvasGroupHide(0, 1, groupWin, .4f));
    }

    private IEnumerator CanvasGroupHide(float start, float end, CanvasGroup group, float time = .3f)
    {
        if (group == null) yield break;

        group.alpha = start;

        if (!group.gameObject.activeSelf)
            group.gameObject.SetActive(true);

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / time);

            group.alpha = Mathf.Lerp(start, end, t);

            yield return null;
        }

        group.alpha = end;

        if (end == 0)
            group.gameObject.SetActive(false);
    }
}

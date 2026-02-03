using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimScillFlouvers : AnimActivScill
{
    public List<Image> images;

    [SerializeField] private float upHeight = 2f;
    [SerializeField] private float upTime = 0.5f;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private float hitTime = 0.15f;
    [SerializeField] private float hitStrength = 0.5f;
    [SerializeField] private int hitVibrato = 10;

    private List<Vector3> startPos = new();
    private List<Sequence> hitSequence = new();

    public List<Image> imagesHide;
    public float moveHeight = 2f;
    public float moveDuration = 1f;
    public float fadeDuration = 0.2f;

    private Dictionary<Image, Color> originalColors = new();

    private IEnumerator ShowOffObjects()
    {
        G.AudioManager.PlaySound(R.Audio.SadoMazo, .5f);

        foreach (Image img in imagesHide)
        {
            if (!img.gameObject.activeInHierarchy)
                img.gameObject.SetActive(true);

            StartCoroutine(AnimateImage(img));
        }

        yield return null;
    }

    private IEnumerator AnimateImage(Image img)
    {
        Color originalColor = originalColors.ContainsKey(img) ?
            originalColors[img] : img.color;

        yield return StartCoroutine(FadeImage(img, 0, 1, fadeDuration));

        yield return new WaitForSeconds(waitTime);

        yield return StartCoroutine(FadeImage(img, 1, 0, fadeDuration, true));
    }

    private IEnumerator FadeImage(Image img, float startAlpha, float endAlpha, float duration, bool isDeack = false)
    {
        float elapsedTime = 0f;
        Color color = img.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            img.color = color;
            yield return null;
        }

        color.a = endAlpha;
        img.color = color;

        if (isDeack)
            model.state.model.DeActivSkil();
    }

    private void Start()
    {
        for (int i = 0; i < imagesHide.Count; i++)
        {
            startPos.Add(imagesHide[i].transform.localPosition);

            hitSequence.Add(DOTween.Sequence());
        }
    }

    public override void Activ()
    {
        StopAllCoroutines();

        foreach(var i in images) 
            StartCoroutine(UpDownAnimationRoutine(i.transform));

        StartCoroutine(ShowOffObjects());
    }

    private IEnumerator UpDownAnimationRoutine(Transform trans)
    {
        Vector3 originalPosition = trans.localPosition;

        Tween upTween = trans.DOLocalMoveY(
            originalPosition.y + upHeight,
            upTime
        ).SetEase(Ease.OutBack);

        yield return upTween.WaitForCompletion();

        yield return new WaitForSeconds(.3f);

        Tween downTween = trans.DOLocalMoveY(
            originalPosition.y - upHeight * 1.4f,
            .3f
        ).SetEase(Ease.InQuad);

        yield return downTween.WaitForCompletion();

        Tween returnTween = trans.DOLocalMoveY(
            originalPosition.y,
            .5f
        ).SetEase(Ease.OutElastic);
    }
}

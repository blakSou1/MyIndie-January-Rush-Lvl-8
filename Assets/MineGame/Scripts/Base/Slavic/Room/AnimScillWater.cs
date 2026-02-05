using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimScillWater : AnimActivScill
{
    private List<Vector3> startPos = new();
    private List<Sequence> hitSequence = new();

    public List<Image> imagesHide;
    public float moveHeight = 2f;
    public float moveDuration = 1f;
    public float fadeDuration = 0.2f;

    public float finalAlpha = .3f;

    private Dictionary<Image, Color> originalColors = new();

    private IEnumerator ShowOffObjects()
    {
        G.AudioManager.PlaySound(R.Audio.water, .5f);

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

        yield return StartCoroutine(FadeImage(img, 0, finalAlpha, fadeDuration));

        yield return new WaitForSeconds(2.5f);

        yield return StartCoroutine(FadeImage(img, finalAlpha, 0, fadeDuration, true));
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

        StartCoroutine(ShowOffObjects());
    }
}

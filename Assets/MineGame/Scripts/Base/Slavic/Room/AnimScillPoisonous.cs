using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimScillPoisonous : AnimActivScill
{
    public List<Image> images;
    public float moveHeight = 2f;
    public float moveDuration = 1f;
    public float waitTime = 2f;
    public float fadeDuration = 0.2f; // время затухания/появления

    private Dictionary<Image, Color> originalColors = new();

    public override void Activ()
    {
        StopAllCoroutines();
        StartCoroutine(ShowOffObjects());
    }

    private IEnumerator ShowOffObjects()
    {
        G.AudioManager.PlaySound(R.Audio.poisonous, .5f);

        foreach (Image img in images)
        {
            if (img == null || !img.gameObject.activeInHierarchy)
                continue;

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

        yield return StartCoroutine(FadeImage(img, 1, 0, fadeDuration));
    }

    private IEnumerator FadeImage(Image img, float startAlpha, float endAlpha, float duration)
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

        model.state.model.DeActivSkil();
    }

}

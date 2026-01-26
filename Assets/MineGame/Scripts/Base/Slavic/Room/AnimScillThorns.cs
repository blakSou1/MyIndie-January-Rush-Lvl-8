using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScillThorns : AnimActivScill
{
    public List<GameObject> pic;

    public float moveHeight = 2f;
    public float moveDuration = 1f;
    public float waitTime = 2f;

    private Dictionary<GameObject, Vector3> originalPositions = new();

    public override void Activ()
    {
        StopAllCoroutines();
        StartCoroutine(MoveAllObjects());
    }

    private IEnumerator MoveAllObjects()
    {
        if (originalPositions.Count == 0)
        {
            foreach (GameObject obj in pic)
            {
                if (obj != null)
                    originalPositions[obj] = obj.transform.position;
            }
        }

        yield return StartCoroutine(MoveUpCoroutine());

        yield return new WaitForSeconds(waitTime);

        yield return StartCoroutine(MoveDownCoroutine());
    }
    private IEnumerator MoveUpCoroutine()
    {
        G.AudioManager.PlaySound(R.Audio.Pic, .5f);

        foreach (GameObject obj in pic)
        {
            if (obj != null)
            {
                obj.transform.DOMoveY(originalPositions[obj].y + moveHeight, moveDuration)
                    .SetEase(Ease.OutQuad);
                yield return new WaitForSeconds(0.1f);
            }
        }

        yield return new WaitForSeconds(moveDuration);
    }

    private IEnumerator MoveDownCoroutine()
    {
        model.StopAllCoroutines();

        foreach (GameObject obj in pic)
        {
            if (obj != null && originalPositions.ContainsKey(obj))
            {
                obj.transform.DOMoveY(originalPositions[obj].y, moveDuration)
                    .SetEase(Ease.InQuad);
            }
        }

        yield return new WaitForSeconds(moveDuration);
    }

}

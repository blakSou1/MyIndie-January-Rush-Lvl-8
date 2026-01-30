using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScillPuk : AnimActivScill
{
    public List<GameObject> pic;

    private Dictionary<GameObject, Vector3> originalPositions = new();

    public override void Activ()
    {
        StopAllCoroutines();
        foreach (GameObject obj in pic)
                obj.transform.DOKill();

        MoveAllObjects();
    }

    private void MoveAllObjects()
    {
        if (originalPositions.Count == 0)
        {
            foreach (GameObject obj in pic)
            {
                if (obj != null)
                    originalPositions[obj] = obj.transform.position;
            }
        }

        foreach (GameObject arrow in pic)
            StartCoroutine(ShootSingleArrow(arrow));
    }
    private IEnumerator ShootSingleArrow(GameObject arrow)
    {
        float drawBackDuration = .2f;
        float shotDuration = 0.5f;

        arrow.transform.DOKill();
        arrow.transform.position = originalPositions[arrow];

        Sequence prepareSequence = DOTween.Sequence();

        prepareSequence
            .Append(arrow.transform.DOMove(
                originalPositions[arrow] + arrow.transform.up * 1,
                drawBackDuration * 1.3f)
                .SetEase(Ease.OutSine))
            .Append(arrow.transform.DOMove(
                originalPositions[arrow] + arrow.transform.up * -1,
                drawBackDuration * 1.7f)
                .SetEase(Ease.OutBack));

        yield return prepareSequence.WaitForCompletion();

        yield return new WaitForSeconds(.3f);

        Vector3 endPosition = arrow.transform.position + arrow.transform.up * 10;

        Sequence shotSequence = DOTween.Sequence();

        shotSequence
            .Append(arrow.transform.DOMove(endPosition, shotDuration)
                .SetEase(Ease.OutQuad))
            .OnStart(() =>
            {
                arrow.transform.DOScale(
                    arrow.transform.localScale * 1.2f,
                    0.1f)
                    .SetLoops(2, LoopType.Yoyo);
            });

        yield return shotSequence.WaitForCompletion();

        arrow.transform.DOKill();

        MoveDownCoroutine();
    }

    private void MoveDownCoroutine()
    {
        foreach (GameObject obj in pic)
            obj.transform.position = originalPositions[obj];

        model.state.model.DeActivSkil();
    }

}

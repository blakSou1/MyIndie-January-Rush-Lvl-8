using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    private TextMeshProUGUI _text;
    [HideInInspector] public CanvasGroup group;

    public void Init(float damage)
    {
        group = GetComponentInParent<CanvasGroup>();
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = damage.ToString();

        transform.DOLocalRotate(new Vector3(0, 0, 10 * 3), 2, RotateMode.LocalAxisAdd);
        transform.DOScale(0, _destroyTime);
        transform.DOLocalMoveY(Random.Range(10, 50), _destroyTime);
        StartCoroutine(FadeOutRandom());
    }

    private IEnumerator FadeOutRandom()
    {
        float fadeDuration = Random.Range(_destroyTime - .4f, _destroyTime);

        group.alpha = 1;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            group.alpha = Mathf.Lerp(1, 0, t);

            yield return null;
        }

        group.alpha = 0;

        Destroy(gameObject, _destroyTime); 
    }
}
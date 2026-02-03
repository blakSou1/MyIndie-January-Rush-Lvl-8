using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 10;
    [HideInInspector] public float currentHealth;
    [SerializeField]private TextMeshProUGUI _textObject;

    [SerializeField] private Image healthBarmage;
    [SerializeField] private Image mob;

    [HideInInspector] public Entity model;

    private void Start()
    {
        currentHealth = health;

        float targetFillAmount = (float)currentHealth / (float)health;
        healthBarmage.fillAmount = targetFillAmount;
    }

    public void Damage(float damage)
    {
        if (currentHealth <= 0) return;

        TextObject currentTextObject; 
        currentHealth -= damage;

        currentTextObject = Instantiate(_textObject, transform.parent).GetComponent<TextObject>();
        currentTextObject.transform.position = new(transform.position.x, transform.position.y + 2, transform.position.z);

        currentTextObject.Init(damage);
            
        float targetFillAmount = (float)currentHealth / (float)health;
        healthBarmage.fillAmount = targetFillAmount;


        if (currentHealth <= 0)
            StartCoroutine(FadeImage(mob, 1, 0, .6f));
    }
    private IEnumerator FadeImage(Image img, float startAlpha, float endAlpha, float duration)
    {
        G.AudioManager.PlaySound(R.Audio.killMain, 0.5f);

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

        model.state.room.Release(model);

        if(model.state.room.objects.Contains(model))
            model.state.room.objects.Remove(model);

        model.StopAllCoroutines();

        model.transform.DOKill(false);

        GetComponent<MoveableBase>().StopAllCoroutines();

        transform.DOKill(false);
        
        yield return null;

        Destroy(gameObject);
    }

}

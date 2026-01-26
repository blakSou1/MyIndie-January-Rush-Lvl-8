using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 10;
    [HideInInspector] public int currentHealth;
    [SerializeField]private GameObject _textObject;

    [SerializeField] private Image healthBarmage;
    [SerializeField] private Image mob;

    private void Start()
    {
        currentHealth = health;

        float targetFillAmount = (float)currentHealth / (float)health;
        healthBarmage.fillAmount = targetFillAmount;
    }

    public void Damage(int damage)
    {
        TextObject currentTextObject = null; 
        currentHealth -= damage;

        if(currentTextObject == null)
        {
            currentTextObject = Instantiate(_textObject, transform).GetComponentInChildren<TextObject>();
            currentTextObject.Init(damage);
        }
            
        float targetFillAmount = (float)currentHealth / (float)health;
        healthBarmage.fillAmount = targetFillAmount;


        if (currentHealth <= 0)
        {
            StartCoroutine(FadeImage(mob, 1, 0, 1.6f));
        }
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

        Destroy(gameObject);
    }

}

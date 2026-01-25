using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 10;
    [HideInInspector] public int currentHealth;
    [SerializeField]private GameObject _textObject;

    [SerializeField] private Image healthBarmage;

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
            //TODO dead
        }
    }
}

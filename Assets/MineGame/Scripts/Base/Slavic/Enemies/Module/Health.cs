using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 10;
    [HideInInspector] public int currentHealth;

    [SerializeField] private Image healthBarmage;

    private void Start()
    {
        currentHealth = health;

        float targetFillAmount = (float)currentHealth / (float)health;
        healthBarmage.fillAmount = targetFillAmount;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;

        float targetFillAmount = (float)currentHealth / (float)health;
        healthBarmage.fillAmount = targetFillAmount;

        if(currentHealth <= 0)
        {
            //TODO dead
        }
    }
}

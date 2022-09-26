using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, IDamageable
{
    private float currentHealth, maxHealth = 5;
    public Image imago;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float amount)
    {
        LifeChange(amount);
        CheckDeath();
    }
    public void LifeChange(float amount)
    {
        currentHealth -= amount;
        ChangeUI();
    }

    public void ChangeUI()
    {
        imago.fillAmount = currentHealth / maxHealth;
    }
    public void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            GameManager.instance.PlayerDeath();
        }
    }
}

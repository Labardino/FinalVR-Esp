using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour, IDamageable
{
    private float maxHealth = 100, currentHealth, dist;
    public Image imago;
    private GameObject playerObj;

    private void Start()
    {
        playerObj = FindObjectOfType<OVRCameraRig>().gameObject;
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
        imago.fillAmount = 1;
    }

    public void Damage(float amount)
    {
        LifeChange(amount);
        CheckDistance(amount);
        CheckDeath();
    }

    public void CheckDistance(float amountDamage)
    {
        dist = Vector3.Distance(this.gameObject.transform.position, playerObj.transform.position);
        Pointsystem.totalPoints += dist;
        Pointsystem.changePoints = true;
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
            this.gameObject.SetActive(false);
        }
    }
}

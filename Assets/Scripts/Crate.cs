using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour, IDamageable
{
    private float maxHealth = 100, currentHealth;
    public Image imago;

    //public Test testo;

    private void Start()
    {
        currentHealth = maxHealth;
        imago.fillAmount = 1;
    }

    public void Damage(float amount)
    {

        LifeChange(amount);
        CheckDeath();
    }

    public void LifeChange(float amount)
    {
        currentHealth -= amount;
        imago.fillAmount = currentHealth / maxHealth;
        //testo = FindObjectOfType<Test>();

        //testo.CustomDebug((currentHealth).ToString());
        TurnRed();


    }

    public void CheckDeath()
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TurnRed()
    {
        MeshRenderer meshRender = GetComponent<MeshRenderer>();
        meshRender.material.color = Color.red;
    }
}

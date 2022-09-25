using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour, IDamageable
{
    private float maxHealth = 100, currentHealth;
    private Image imago;

    public Test testo;


    private void Start()
    {
        currentHealth = maxHealth;
        imago.fillAmount = 1;
        //testo = FindObjectOfType<Test>();

    }
    private void Update()
    {
        //testo.CustomDebug((currentHealth/maxHealth).ToString());

    }

    public void Damage(int amount)
    {
        UpdateLife(amount);
        TurnRed();
        CheckDeath();
    }

    public void UpdateLife(int amount)
    {
        currentHealth = currentHealth -  amount;
        imago.fillAmount = currentHealth/maxHealth;
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

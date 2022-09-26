using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crate : MonoBehaviour, IDamageable
{
    private float maxHealth = 50, currentHealth;
    public Image imago;
    private GameObject playerObj;
    public TextMeshProUGUI textar;

    //public Test testo;
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
        float dist = Vector3.Distance(this.gameObject.transform.position, playerObj.transform.position);
        textar.text = ((dist).ToString());
        float points = amountDamage * dist;
        Pointsystem.totalPoints += points;
        Pointsystem.changePoints = true;
    }

    public void LifeChange(float amount)
    {
        currentHealth -= amount;
        imago.fillAmount = currentHealth / maxHealth;

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

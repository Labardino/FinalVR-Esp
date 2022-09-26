using UnityEngine;

public interface IDamageable
{
    void Damage(float amount);
    void LifeChange(float amount);

    void CheckDeath();
}

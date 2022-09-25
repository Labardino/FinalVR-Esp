using UnityEngine;

public interface IDamageable
{
    void Damage(int amount);
    void UpdateLife(int amount);

    void CheckDeath();
}

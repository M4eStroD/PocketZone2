using UnityEngine;

public class Characters : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthBar _healthBar;

    public int _currentHealth;

    public void SetBar()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth, _currentHealth);
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_maxHealth, _currentHealth);
    }
}

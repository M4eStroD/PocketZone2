using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : Characters
{
    public Inventory inventory;
    public GameObject _panelDie;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (_currentHealth <= 0)
        {
            Time.timeScale = 0f;
            _panelDie.SetActive(true);
        }
    }

    private void Start()
    {
        SetBar();
    }
}

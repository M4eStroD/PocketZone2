using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;


    public void SetMaxHealth(int maxHealth, int curHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = curHealth;
    }

    public void SetHealth(int maxHealth, int curHealth)
    {
        slider.value = curHealth;
    }
}

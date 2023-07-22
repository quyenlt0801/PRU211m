using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreepBar : MonoBehaviour
{
    public static CreepBar Instance { get; private set; }
    public Slider slider;

    public Gradient gradient;

    public Image fill;
    private void Awake()
    {
        Instance = this;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

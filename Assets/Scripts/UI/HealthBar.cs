using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player player;
    public Slider slider;
    public void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        slider.value = player.GetHealth();
        slider.maxValue = player.GetMaxHealth();
        slider.minValue = -Mathf.Round((player.GetMaxHealth()-5)/5);
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{
    private Enemy boss;
    EnemyData data;
    public Slider slider;
    public void Start(){
        boss = GameObject.FindWithTag("Boss").GetComponent<Enemy>();
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
    }
    void Update(){
        slider.value = boss.GetHealth();
        slider.maxValue = data.getMaxhealth(4);
        slider.minValue = -Mathf.Round((data.getMaxhealth(4)-5)/5);
    }
}


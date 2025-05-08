using UnityEngine;
using UnityEngine.UI;

public class UltChargeUI : MonoBehaviour
{
    private WeaponAttacks player;
    public Slider slider;
    public void Start()
    {
        player = GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>();
    }
    void Update()
    {
        slider.value = player.GetUltCharge();
        slider.maxValue = player.GetUltChargeMax();
        slider.minValue = -Mathf.Round((player.GetUltChargeMax()-5)/5);
    }
}

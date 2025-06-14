using UnityEngine;

public class HealsManger : MonoBehaviour
{
    public GameObject[] bars;
    public void swapHealBar(bool state){
        bars[0].SetActive(!state);
        bars[1].SetActive(state);
    }
}

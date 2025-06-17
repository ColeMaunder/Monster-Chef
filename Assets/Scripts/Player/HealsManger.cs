using UnityEngine;
using System.Collections.Generic;

public class HealsManger : MonoBehaviour
{
    private Player player;
    private List<int> UpgradeIndex = new List<int>();
    public GameObject[] bars;
    void Start(){
         player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    
    public void swapHealBar(int index){
        if (!UpgradeIndex.Contains(index))
        {
            bars[index].SetActive(false);
            bars[index + 1].SetActive(true);
            GameObject.FindWithTag("Player").GetComponent<Player>().HealthFull();
        }
    }
}

using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class HealsUI : MonoBehaviour
{
    private Player player;

    [SerializeField] private List<GameObject> healIconsUnlocked = new List<GameObject>();
    [SerializeField] private List<GameObject> healIconsLockedFull = new List<GameObject>();
    [SerializeField] private List<GameObject> healIconsLockedEmpty = new List<GameObject>();
    private List<int> UpgradeIndex = new List<int>();
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        if (player.GetHeals() < player.GetMaxHeals()){
            for (int i = 0; i < player.GetMaxHeals(); i++)
            {
                if (i > player.GetHeals() - 1)
                {
                    healIconsUnlocked[i].SetActive(false);
                }
                else
                {
                    healIconsUnlocked[i].SetActive(true);
                }
            }
        }
    }
    public void Fountain() {
        foreach (GameObject i in healIconsUnlocked){
            i.SetActive(true);
        }
    }
    public GameObject GetHeal(int index){
        return healIconsUnlocked[index];
    }
    public void addPotion(int index) {
        if (!UpgradeIndex.Contains(index)) {
            UpgradeIndex.Add(index);
            healIconsUnlocked.Add(healIconsLockedFull[0]);
            healIconsLockedEmpty[0].SetActive(true);
            healIconsLockedFull.RemoveAt(0);
            healIconsLockedEmpty.RemoveAt(0);
            GameObject.FindWithTag("Player").GetComponent<Player>().RefillHeals();
        }
    }
        
}

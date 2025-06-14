using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class HealsUI : MonoBehaviour
{
    private Player player;

    [SerializeField] private List<GameObject> healIcons = new List<GameObject>();
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
                    healIcons[i].SetActive(false);
                }
                else
                {
                    healIcons[i].SetActive(true);
                }
            }
        }
    }
    public void Fountain() {
        foreach (GameObject i in healIcons){
            i.SetActive(true);
        }
    }
    public GameObject GetHeal(int index){
        return healIcons[index];
    }
    public void addPotion(GameObject potion)
    {
        healIcons.Add(potion);
    }
}

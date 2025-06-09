using TMPro;
using UnityEngine;

public class HealsUI : MonoBehaviour
{
    private Player player;
    public GameObject[] healIcons;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetHeals() < player.GetMaxHeals())
        {
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
    public void Fountain()
    {
        healIcons[0].SetActive(true);
        healIcons[1].SetActive(true);
        healIcons[2].SetActive(true);
    }
    public GameObject GetHeal(int index){
        return healIcons[index];
    }
}

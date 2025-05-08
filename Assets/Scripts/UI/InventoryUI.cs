using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text[] counts;
    public GameObject[] icons;
    private PlayerInventory player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<counts.Length; i++){
            int enemy = player.GetEnemy(i);
            if (enemy > 0){
                icons[i].SetActive(true);
                counts[i].text = "" + enemy;
            }else{
                icons[i].SetActive(false);
            }
            
        }
    }
}

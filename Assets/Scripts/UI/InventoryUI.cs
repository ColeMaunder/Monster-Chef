using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text[] counts;
    public GameObject[] icons;
    public TMP_Text explaner;
    public TMP_Text nameTXT;
    public string[] explainations;
    public string[] names;
    private PlayerInventory player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<counts.Length; i++){
            int item= player.GetItem(i);
            if (item > 0){
                icons[i].SetActive(true);
                counts[i].text = "" + item;
            }else{
                icons[i].SetActive(false);
            }
            
        }
    }
    public void explane(int textID){

        explaner.text = explainations[textID];
        nameTXT.text = names[textID];
    }
    
}

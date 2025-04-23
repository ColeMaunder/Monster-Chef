using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text frog;
    public TMP_Text slime;
    private PlayerInventory player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
            frog.text = "" + player.GetFrog();
            slime.text = "" + player.GetSlime();

        
    }
}

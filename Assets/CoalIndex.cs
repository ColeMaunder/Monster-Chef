using UnityEngine;

public class CoalIndex : MonoBehaviour{
    [SerializeField] int CoalID;
    PlayerData data;
    void Start()
    {
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        if (data.collectedCoal(CoalID)){
            Destroy(this.gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();
        if (inventory != null){
            inventory.AddItem(4);
            data.addCoal(CoalID);
            Destroy(this.gameObject);
        }
    }

}

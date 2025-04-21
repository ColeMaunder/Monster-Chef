using UnityEngine;

public class PlayerGrave : MonoBehaviour
{PlayerInventory inventory;
    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
    }
    public int[] droppedInventory;
    private void OnTriggerEnter2D(Collider2D collision){
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();
        if (inventory != null){
            inventory.PickUpInventory();
            Destroy(this.gameObject);
        }
    }
}

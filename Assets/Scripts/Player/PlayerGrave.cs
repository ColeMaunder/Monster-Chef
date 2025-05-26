using NUnit.Framework.Internal;
using UnityEngine;

public class PlayerGrave : MonoBehaviour
{
    public int[] droppedInventory;
    private void OnTriggerEnter2D(Collider2D collision){
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();
        if (inventory != null){
            inventory.PickUpInventory();
            Destroy(this.gameObject);
        }
    }
    
    public void SetDroppedInventory(int[] invIn)
    {
        droppedInventory = invIn;
    }
}

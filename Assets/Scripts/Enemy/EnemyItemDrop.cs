using UnityEngine;

public class EnemyItemDrop : MonoBehaviour
{
    public int enemyDrop;
    private void OnTriggerEnter2D(Collider2D collision){
        PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();
        if (inventory != null){
            inventory.AddItem(enemyDrop);
            Destroy(this.gameObject);
        }
    }
}

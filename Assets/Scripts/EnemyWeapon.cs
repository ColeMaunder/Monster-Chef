using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision){
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null){
            player.damage(damage);
            print("Slime hit");
        }
    }
}

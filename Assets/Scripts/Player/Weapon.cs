using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision){
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null){
            enemy.Damage(damage);
        }
    }
}

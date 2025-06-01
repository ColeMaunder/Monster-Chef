using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1f;
    public float knockBack = 1f;

    private void OnTriggerEnter2D(Collider2D collision){
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null){
            if (collision.gameObject.GetComponent<EnemyLocalData>().getVulnrable()){
                enemy.Damage(this.transform.position,damage,knockBack);
            }
        }
    }
}

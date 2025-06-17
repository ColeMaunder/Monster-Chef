using UnityEngine;

public class EnemyTrapWeapon : MonoBehaviour
{
    [SerializeField]
    private float damage = 1f;
    [SerializeField]
    private float trapTime = 3f;
    private bool hitPlayer = false;
    void OnEnable()
    {
        hitPlayer = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null){
            hitPlayer = true;
            player.trapDamage(damage, trapTime);
            print("Enemy hit");
        }
    }
    public bool getHitPlayer(){
        return hitPlayer;
    }
}

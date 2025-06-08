using UnityEngine;

public class EnemyTrapWeapon : MonoBehaviour
{
    [SerializeField]
    private float damage = 1f;
    [SerializeField]
    private float tickTime = 0.5f;
    [SerializeField]
    private float tickDamage = 1f;
    [SerializeField]
    private float tickEnd = 4f;
    [SerializeField]
    private int wrigleThreshold = 6;
    private bool hitPlayer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            hitPlayer = true;
            player.trapDamage(damage, tickDamage, tickTime, tickEnd, wrigleThreshold);
            print("Enemy hit");
        }
        else
        {
            hitPlayer = false;
        }
    }
    public bool getHitPlayer(){
        return hitPlayer;
    }
}

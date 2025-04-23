using UnityEngine;

public class FrogAttack : MonoBehaviour
{
    private EnemyData data  = null;
    public float veriance = 0.5f;
    public float atkCoolDown = 3f;
    public GameObject projectile;
    public float fireForce;
    public float hangTime = 2f;
    private float timer = 0f;
    private bool isAttacking = false;
    public Rigidbody2D enmenyBody;

    void Start()
    {
       data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
       isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isAttacking){
            if (data.PlayerDistance(enmenyBody) > (data.GetFavoredDistance(2) - veriance) && data.PlayerDistance(enmenyBody) < (data.GetFavoredDistance(2) + veriance)){
                 Spit();
            }
        }else{
            AttackTimer();
        }
    }
    
    void Spit(){
            GameObject intProjectile = Instantiate(projectile, transform.position, transform.rotation);
            intProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up *fireForce, ForceMode2D.Impulse);
            isAttacking = true;
            Destroy(intProjectile,hangTime);
        }
    void AttackTimer(){
        timer += Time.deltaTime;
        if (timer >= atkCoolDown){
            timer = 0;
            isAttacking = false;
        }
    }
}


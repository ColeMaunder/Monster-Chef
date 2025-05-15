using UnityEngine;

public class FrogAttack : MonoBehaviour
{
    private EnemyData data  = null;
    private EnemyLocalData dataLocal  = null;
    public float veriance = 0.5f;
    public float atkCoolDown = 3f;
    public float atkTime = 1f;
    public GameObject projectile;
    public float fireForce;
    public float hangTime = 2f;
    private float timer = 0f;
    private Rigidbody2D enmenyBody;
    private Animator animator;

    void Start()
    {
        GameObject enemy = transform.parent.gameObject;
        enmenyBody = enemy.GetComponent<Rigidbody2D>();
        animator = enemy.GetComponent<Animator>();
        dataLocal = enemy.GetComponent<EnemyLocalData>();
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!dataLocal.getIsAttacking()){
            if (data.PlayerDistance(enmenyBody) > (data.GetFavoredDistance(2) - veriance) && data.PlayerDistance(enmenyBody) < (data.GetFavoredDistance(2) + veriance)){
                 Spit();
            }
        }else{
            AttackTimer();
        }
    }
    
    void Spit(){
            dataLocal.setCanMove(false);
            GameObject intProjectile = Instantiate(projectile, transform.position, transform.rotation);
            intProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up *fireForce, ForceMode2D.Impulse);
            dataLocal.setIsAttacking(true);
            Destroy(intProjectile,hangTime);
        }
    void AttackTimer(){
        timer += Time.deltaTime;
        if (timer >= atkCoolDown){
            timer = 0;
            dataLocal.setIsAttacking(false);
            dataLocal.setCanMove(true);
        } else if (timer >= atkTime){

        }
    }
}


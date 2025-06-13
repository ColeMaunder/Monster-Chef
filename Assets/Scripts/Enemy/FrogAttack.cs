using UnityEngine;

public class FrogAttack : MonoBehaviour
{
    private EnemyData data  = null;
    private EnemyLocalData dataLocal  = null;
    public float veriance = 1f;
    public float atkCoolDown = 3f;
    public float atkTime = 1f;
    public GameObject projectile;
    public float fireForce;
    public float hangTime = 2f;
    private float timer = 0f;
    public float atkStartup = 1f;
    private Rigidbody2D enmenyBody;
    private Animator animator;
    private bool attacked;

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
            if (data.PlayerDistance(enmenyBody) < (data.getFavoredDistance(2) + veriance)){
                dataLocal.setIsAttacking(true);
            }
        }else{
            AttackTimer();
        }
    }
    
    void Spit(){
        data.playAttackSound(dataLocal.getEnemyIndex());
        attacked = true;
        dataLocal.setCanMove(false);
        animator.SetBool("attackCharged", true);
        animator.SetBool("attack", false);
        GameObject intProjectile = Instantiate(projectile, transform.position, transform.rotation);
        intProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up *fireForce, ForceMode2D.Impulse);
        Destroy(intProjectile,hangTime);
    }
    void AttackTimer() {
        if (timer >= (atkCoolDown + atkTime + atkStartup)) {
            timer = 0;
            dataLocal.setIsAttacking(false);
        } else if (timer >= (atkTime + atkStartup)) {
            animator.SetBool("attackCharged", false);
            dataLocal.setCanMove(true);
            attacked = false;
        } else if (timer >= atkStartup ) {
            if (!attacked){
                Spit();
            }
        } else {
            animator.SetBool("attack", true);
        }
         timer += Time.deltaTime;
    }
}


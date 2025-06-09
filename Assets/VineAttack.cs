using UnityEngine;

public class VineAttack : MonoBehaviour{
    private EnemyData data = null;
    private EnemyLocalData dataLocal  = null;
    public float veriance = 1f;
    public float atkCoolDown = 3f;
    public float sweepTime = 1f;
    public float slamTime = 1f;
    private float atkTime = 1f;
    private float timer = 0f;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float fireForce = 20;
    [SerializeField]
    private float hangTime = 2f;
    private Rigidbody2D enmenyBody;
    private Animator animator;
    [SerializeField]
    private GameObject slam;
    [SerializeField]
    private GameObject sweep;

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
            if (data.PlayerDistance(enmenyBody) < data.getFavoredDistance(dataLocal.getEnemyIndex())) {
                Sweep();
                }else if( data.PlayerDistance(enmenyBody) < (data.getFavoredDistance(dataLocal.getEnemyIndex()) + veriance)){
                    Slam();
                }
                dataLocal.setIsAttacking(true);
        } else{
            AttackTimer();
        }
    }
    
    void Sweep(){
        data.playAttackSound(dataLocal.getEnemyIndex());
        atkTime = sweepTime;
        dataLocal.setCanMove(false);
        sweep.SetActive(true);
//        animator.SetBool("sweep", true);
        animator.SetBool("attack", true);
    }
    void Slam(){
        data.playAttackSound(dataLocal.getEnemyIndex());
        dataLocal.setCanLook(false);
        atkTime = slamTime;
        dataLocal.setCanMove(false);
        slam.SetActive(true);
    //    animator.SetBool("sweep", false);
        animator.SetBool("attack", true);
        GameObject intProjectile = Instantiate(projectile, transform.position, transform.rotation);
        intProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up *fireForce, ForceMode2D.Impulse);
        Destroy(intProjectile,hangTime);
    }
    void AttackTimer() {
        if (timer >= (atkCoolDown + atkTime)) {
            timer = 0;
            dataLocal.setIsAttacking(false);
        } else if (timer >= atkTime ) {
            dataLocal.setCanMove(true);
            sweep.SetActive(false);
            slam.SetActive(false);
            dataLocal.setCanLook(true);
            dataLocal.setCanMove(true);
        } else {
            animator.SetBool("attack", true);
        }
         timer += Time.deltaTime;
    }
}


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
    [SerializeField]
    private float startTimeSlam = 0.5f;
    [SerializeField]
    private float startTimeSweep = 0.5f;
    private Rigidbody2D enmenyBody;
    private Animator animator;
    [SerializeField]
    private GameObject slam;
    [SerializeField]
    private GameObject sweep;
    private bool isSweep;
    private bool shaocked = false;
    bool attacked = false;
    private float startTime = 0;
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
                startup(true);
            }else if( data.PlayerDistance(enmenyBody) < (data.getFavoredDistance(dataLocal.getEnemyIndex()) + veriance)){
                startup(false);
            }
        } else{
            AttackTimer();
        }
    }
    
    private void attack(){
        if(!attacked){
          if (isSweep){
                Sweep();
            }else{
                Slam();
            }
            attacked = true; 
        }
    }
    private void startup(bool inSweep)
    {
        isSweep = inSweep;
        animator.SetBool("sweep", isSweep);
        animator.SetBool("attack", true);
        dataLocal.setCanMove(false);
        dataLocal.setIsAttacking(true);
        if (isSweep){
            startTime = startTimeSweep;
        }else{
            startTime = startTimeSlam;
        }
    }
    void Sweep(){
        data.playAttackSound(dataLocal.getEnemyIndex());
        atkTime = sweepTime;
        sweep.SetActive(true);
        
    }
    void Slam(){
        data.playAttackSound(dataLocal.getEnemyIndex());
        dataLocal.setCanLook(false);
        atkTime = slamTime;
        slam.SetActive(true);
    }
    void shock(){
        if (!isSweep){
            if (!shaocked){
                GameObject intProjectile = Instantiate(projectile, transform.position + new Vector3(0, 1, 0), transform.rotation);
                intProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
                Destroy(intProjectile, hangTime);
                shaocked = true;
            }
        }
    }
    void AttackTimer() {
        if (timer >= (atkCoolDown + atkTime + startTime)) {
            timer = 0;
            dataLocal.setIsAttacking(false);
            shaocked = false;
            attacked = false;
        } else if (timer >= (atkTime + startTime)) {
            shock();
            animator.SetBool("sweep", false);
            animator.SetBool("attack", false);
            dataLocal.setCanMove(true);
            sweep.SetActive(false);
            slam.SetActive(false);
            dataLocal.setCanLook(true);
            dataLocal.setCanMove(true);
        } else if(timer >= startTime){
            attack();
        }
         timer += Time.deltaTime;
    }
}


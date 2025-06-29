using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    private EnemyData data  = null;
    public float damage = 1f;
    public float veriance = 0.5f;
    public float atkCoolDown = 3f;
    public float lunge = 5f;
    public float backDuration = 5f;
    public float AtkDuration = 1f;
    private float timer = 0f;
    private Rigidbody2D enmenyBody;
    private bool isAttacking = false;
    EnemyLocalData localData;

    void Start()
    {
        enmenyBody = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        localData =  transform.parent.gameObject.GetComponent<EnemyLocalData>();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isAttacking){
            if (data.PlayerDistance(enmenyBody) > (data.getFavoredDistance(0) - veriance) && data.PlayerDistance(enmenyBody) < (data.getFavoredDistance(0) + veriance)){
                 Attack();
            }
        }else{
            AttackTimer();
        }
    }
    
    void Attack(){
        data.playAttackSound(localData.getEnemyIndex());
        enmenyBody.linearVelocity = transform.up * lunge;
        isAttacking = true;
        localData.setCanMove(false);
    }
    void AttackTimer(){
        timer += Time.deltaTime;
        if (timer >= (atkCoolDown + AtkDuration + backDuration)){
            timer = 0;
            isAttacking = false;
        }else if(timer >= AtkDuration + backDuration){
            enmenyBody.linearVelocity = Vector2.zero;
            localData.setCanMove(true);
        }else if(timer >= AtkDuration){
            enmenyBody.linearVelocity = transform.up * -lunge;
            print("back");
        }
    }
}

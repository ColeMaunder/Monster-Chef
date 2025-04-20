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
    public Rigidbody2D enmenyBody;

    void Start()
    {
       data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
       data.SetIsAttacking(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!data.GetIsAttacking()){
            if (data.PlayerDistance(enmenyBody) > (data.GetFavoredDistance() - veriance) && data.PlayerDistance(enmenyBody) < (data.GetFavoredDistance() + veriance)){
                 Attack();
            }
        }else{
            AttackTimer();
        }
    }
    
    void Attack(){
            enmenyBody.linearVelocity = transform.up * lunge;
            data.SetIsAttacking(true);
            data.SetCanMove(false);
        }
    void AttackTimer(){
        timer += Time.deltaTime;
        if (timer >= (atkCoolDown + AtkDuration + backDuration)){
            timer = 0;
            data.SetIsAttacking(false);
        }else if(timer >= AtkDuration + backDuration){
            enmenyBody.linearVelocity = Vector2.zero;
            data.SetCanMove(true);
        }else if(timer >= AtkDuration){
            enmenyBody.linearVelocity = transform.up * -lunge;
            print("back");
        }
    }
}

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
                 Spit();
            }
        }else{
            AttackTimer();
        }
    }
    
    void Spit(){
            GameObject intProjectile = Instantiate(projectile, transform.position, transform.rotation);
            intProjectile.GetComponent<Rigidbody2D>().AddForce(transform.up *fireForce, ForceMode2D.Impulse);
            data.SetIsAttacking(true);
            Destroy(intProjectile,hangTime);
        }
    void AttackTimer(){
        timer += Time.deltaTime;
        if (timer >= atkCoolDown){
            timer = 0;
            data.SetIsAttacking(false);
        }
    }
}


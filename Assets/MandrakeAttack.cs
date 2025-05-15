using UnityEngine;

public class MandrakeAttack : MonoBehaviour
{
   private EnemyData data  = null;
    public float damage = 1f;
    public float veriance = 0.5f;
    public float atkCoolDown = 3f;
    public float lunge = 5f;
    public float sitDuration = 5f;
    public float AtkDuration = 1f;
    public float digDuration = 1f;
    private float timer = 0f;
    public Rigidbody2D enmenyBody;
    private bool isAttacking = false;
    public GameObject localDataObj;
    EnemyLocalData localData;
    public GameObject[] attacks;
    public GameObject hurtBox;

    void Start()
    {
       data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
       localData = localDataObj.GetComponent<EnemyLocalData>();
       isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isAttacking){
            if (data.PlayerDistance(enmenyBody) > (data.GetFavoredDistance(0) - veriance) && data.PlayerDistance(enmenyBody) < (data.GetFavoredDistance(0) + veriance)){
                 Snap();
            }
        }else{
            AttackTimer();
        }
    }
    void Snap(){
            attacks[0].SetActive(true);
            hurtBox.SetActive(true);
            enmenyBody.linearVelocity = transform.up * lunge;
            isAttacking = true;
            localData.setCanMove(false);
    }
    void AttackTimer(){
        timer += Time.deltaTime;
        if (timer >= (atkCoolDown + AtkDuration + sitDuration+ digDuration)){
            timer = 0;
            isAttacking = false;
        }else if(timer >= (AtkDuration + sitDuration + digDuration)){
            localData.setCanMove(true);
        }else if(timer >= (AtkDuration + sitDuration)){
            hurtBox.SetActive(false);
        }else if(timer >= AtkDuration){
            attacks[0].SetActive(false);
        }
    }
    }

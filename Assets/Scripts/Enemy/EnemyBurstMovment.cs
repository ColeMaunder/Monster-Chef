using UnityEngine;

public class EnemyBurstMovment : MonoBehaviour
{
    private GameObject enemy;
    private EnemyData data  = null;
    private Rigidbody2D enmenyBody;
    public GameObject localDataObj;
    EnemyLocalData localData;
    private Animator animator;
    public float moveCoolDown;
    public float moveTime;
    public int enemyType = 2;

    void Start()
    {
        enemy = transform.parent.gameObject;
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        enmenyBody = enemy.GetComponent<Rigidbody2D>();
        localData = enemy.GetComponent<EnemyLocalData>();
        animator = enemy.GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(localData.GetCanMove()){
            float distance = data.PlayerDistance(enmenyBody);
            if (distance < data.GetAgroRaing(enemyType)){
                
                moveTimer(moveTime);
                if (distance > data.GetFavoredDistance(enemyType)){
                    localData.SetCanLook(false);
                    animator.SetBool("walking", true);
                    enmenyBody.transform.position += transform.up * data.GetEnemySpeed(enemyType) * Time.deltaTime;
                }else if (distance < data.GetFavoredDistance(enemyType)){
                    enmenyBody.transform.position -= transform.up * data.GetEnemySpeed(enemyType) * Time.deltaTime;
                    localData.SetCanLook(false);
                    animator.SetBool("walking", true);
                }
            }
        }else{
            localData.SetCanLook(true);
            animator.SetBool("walking", false);
            moveTimer(moveCoolDown);
            print ("movment stopped");
        }  
    }

    void moveTimer(float hold){
        if (timer >= hold){
            timer = 0;
            localData.SetCanMove(!localData.GetCanMove());
        }
    }
    private float timer = 0f;
}

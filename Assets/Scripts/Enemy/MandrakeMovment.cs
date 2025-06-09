using UnityEngine;
using System.Collections;

public class MandrakeMovment : MonoBehaviour
{
    private GameObject enemy;
    private EnemyData data  = null;
    private Rigidbody2D enmenyBody;
    private Collider2D enemyColider;
    EnemyLocalData localData;
    private Animator animator;
    public float moveCoolDown;
    public float moveTime;
    private float timer = 0f;
    bool moving = true;
    private PlayerData player;
    


    void Start()
    {
        enemy = transform.parent.gameObject;
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        enmenyBody = enemy.GetComponent<Rigidbody2D>();
        localData = enemy.GetComponent<EnemyLocalData>();
        animator = enemy.GetComponent<Animator>();
        localData.setFullVulnrable(false);
        player = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
    }

    void Update()
    {
        if(localData.getCanMove()){
            if (moving) {
                localData.setCanLook(false);
                if (data.PlayerDistance(enmenyBody) > data.getFavoredDistance(localData.getEnemyIndex()) && !player.getTrapped()){
                    moveTimer();
                    animator.SetBool("walking", true);
                    enmenyBody.transform.position += transform.up * data.getEnemySpeed(localData.getEnemyIndex()) * Time.deltaTime;
                    localData.setFullVulnrable(false);
                }  
            } else {
                moveCooldoen();
            }
        }else{
            moving = false;
            localData.setCanLook(true);
            animator.SetBool("walking", false);
        }  
    }

    void moveTimer(){
        timer += Time.deltaTime;
        if (timer >= moveTime){
            timer = 0;
            localData.setCanLook(true);
            animator.SetBool("walking", false);
            moving = false;
        }
    }
    void moveCooldoen(){
        localData.setVulnrable(true);
        timer += Time.deltaTime;
        if (timer >= moveCoolDown){
            timer = 0;
            moving = true;
        }
    }
}


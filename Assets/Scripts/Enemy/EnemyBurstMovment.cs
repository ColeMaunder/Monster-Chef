using UnityEngine;
using System.Collections;

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
    private Direction direction;
    private GameObject player;
    private float timer = 0f;
    bool moving = false;
    int [] directionXY;
    public float spinSlow = 1;
    private float curentDistance;
    private bool checkedDistance = false;

    void Start()
    {
        enemy = transform.parent.gameObject;
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        enmenyBody = enemy.GetComponent<Rigidbody2D>();
        localData = enemy.GetComponent<EnemyLocalData>();
        animator = enemy.GetComponent<Animator>();
        direction = this.GetComponent<Direction>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(localData.getCanMove()){
            curentDistance = data.PlayerDistance(enmenyBody);
            if (moving){
                localData.setCanLook(false);
                moveTimer(moveTime);
                enmenyBody.transform.position += transform.up * data.GetEnemySpeed(enemyType) * Time.deltaTime;
            }else if(!checkedDistance){
                localData.setCanLook(false);
                checkedDistance = true;
                if(curentDistance < data.GetFavoredDistance(enemyType)){
                    directionXY = direction.DirectionAuto(player.transform.position);
                    StartCoroutine(enemySpin());
                } else {
                    animator.SetBool("walking", true);
                    moving = true;
                    checkedDistance = false;
                }
            }
        }else{
            moving = false;
            localData.setCanLook(true);
            animator.SetBool("walking", false);
            if (!localData.getIsAttacking()){
                moveTimer(moveCoolDown);
            }
        }  
    }

    void moveTimer(float hold){
        timer += Time.deltaTime;
        if (timer >= hold){
            timer = 0;
            localData.setCanMove(!localData.getCanMove());
        }
    }

    public IEnumerator enemySpin(){
        int x = directionXY[0];
        int y = directionXY[1];
        int randomDirection = Random.Range(0, 2);
        if (x != 0 && y != 0){
            print("chaking 1");
            if (randomDirection == 0){
                direction.SetDirection(0,y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x,y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x,0);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x,-y);
            }else{
                direction.SetDirection(x,0);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(x,-y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(0,-y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x,-y);
            }
        }else{
            print("chaking 2");
            int direcNum;
                if(randomDirection == 0){
                    direcNum = 1;
                }else{
                    direcNum = -1;
                }
            if (x == 0){
                direction.SetDirection(direcNum,y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(direcNum,0);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(direcNum,-y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(0,-y);
            }else{
                direction.SetDirection(x,direcNum);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(0,direcNum);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x,direcNum);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x,0);
            }
        }
        animator.SetBool("walking", true);
        moving = true;
        checkedDistance = false;
    }
}


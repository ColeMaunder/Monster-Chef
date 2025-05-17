using UnityEngine;
using System.Collections;

public class EnemyBurstMovment : MonoBehaviour
{
    private GameObject enemy;
    private EnemyData data  = null;
    private Rigidbody2D enmenyBody;
    EnemyLocalData localData;
    private Animator animator;
    public float moveCoolDown;
    public float moveTime;
    public int enemyType = 2;
    private Direction direction;
    private GameObject player;
    private float timer = 0f;
    bool moving = true;
    int [] directionXY;
    public float spinSlow = 1;
    private float curentDistance;
    private bool checkedDistance = false;
    private bool spin;
    

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
            if (moving) {
                localData.setCanLook(false);
                if (checkedDistance) {
                    moveTimer();
                    animator.SetBool("walking", true);
                    enmenyBody.transform.position += transform.up * data.GetEnemySpeed(enemyType) * Time.deltaTime;
                } else if (!spin){
                    checkedDistance = true;
                    curentDistance = data.PlayerDistance(enmenyBody);
                    if (curentDistance < data.GetFavoredDistance(enemyType)) {
                        directionXY = direction.DirectionAuto(player.transform.position);
                        direction.SetDirection(-directionXY[0], -directionXY[1]);
                        //StartCoroutine(enemySpin());
                    } else {
                        moving = true;
                    }
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
        timer += Time.deltaTime;
        if (timer >= moveCoolDown){
            timer = 0;
            moving = true;
            checkedDistance = false;
        }
    }

    public IEnumerator enemySpin()
    {
        spin = true;
        int x = directionXY[0];
        int y = directionXY[1];
        int randomDirection = Random.Range(0, 2);
        if (x != 0 && y != 0)
        {
            print("chaking 1");
            if (randomDirection == 0)
            {
                direction.SetDirection(0, y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x, y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x, 0);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x, -y);
            }
            else
            {
                direction.SetDirection(x, 0);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(x, -y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(0, -y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x, -y);
            }
        }
        else
        {
            print("chaking 2");
            int direcNum;
            if (randomDirection == 0)
            {
                direcNum = 1;
            }
            else
            {
                direcNum = -1;
            }
            if (x == 0)
            {
                direction.SetDirection(direcNum, y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(direcNum, 0);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(direcNum, -y);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(0, -y);
            }
            else
            {
                direction.SetDirection(x, direcNum);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(0, direcNum);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x, direcNum);
                yield return new WaitForSeconds(spinSlow);
                direction.SetDirection(-x, 0);
            }
        }
        moving = true;
        spin = false;
    }
}


using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Direction: MonoBehaviour
{

    private PlayerData data  = null;
    private EnemyLocalData localEnemy = null;
    private Animator animator;
    private bool isPlayer;
    private GameObject subject = null;
    private GameObject player = null;
    private Player playerState;
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake(){
        subject = transform.parent.gameObject;
        player = GameObject.FindWithTag("Player");
        playerState = player.GetComponent<Player>();
        rb = subject.GetComponent <Rigidbody2D>();
        animator = subject.GetComponent<Animator>();
        if (subject == player){
            isPlayer = true;
            data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        }else{
            localEnemy = transform.parent.gameObject.GetComponent<EnemyLocalData>();
        }
   }

    // Update is called once per frame
    void Update()
    {
        if(playerState.GetPlayerAlive()){
            int [] direction;
            if (isPlayer){
                if (data.GetMouseMovment()){
                    direction = DirectionAuto(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }else{
                    direction = DirectionKey();
                }
                SetDirection(direction[0],direction[1]);
            }else{
                if (localEnemy.getCanLook()){
                    direction = DirectionAuto(player.transform.position);
                    SetDirection(direction[0],direction[1]);
                }
            }  
        } 
    }
    public int[] DirectionAuto(Vector3 comperePosition){
        int [] direction = {0,0};
        float positonDiffX = comperePosition.x - transform.position.x;
        //print(positonDiffX);
        float positonDiffY = comperePosition.y - transform.position.y;
        //print(positonDiffY);
        if (positonDiffY > 0){
            direction[0] = 1;
        }else{
            direction[0] = -1;
        }
        if (positonDiffX < 0){
            direction[1] = -1;
        }else{
            direction[1] = 1;
        }

        if (Mathf.Abs(positonDiffY) < Mathf.Abs(positonDiffX/2)){
            direction[0] = 0;
            //print("full side");
        } else if(Mathf.Abs(positonDiffY) > Mathf.Abs(positonDiffX*2)){
            direction[1] = 0;
            //print("full up");
            }
        return direction;
    }
   private int[] DirectionKey(){
        int [] direction = {0,0};
        if(Input.GetKey(data.GetKey(0)) || Input.GetKey(data.GetKey(1))){
                if (Input.GetKey(data.GetKey(0))){
                direction[0] = 1;
                print("up");
            } else if (Input.GetKey(data.GetKey(1))){
                direction[0] = -1;
                print("down");
            }
        }
        if(!Input.GetKey(data.GetKey(2)) || !Input.GetKey(data.GetKey(3))){
            if (Input.GetKey(data.GetKey(2))){
                direction[1] = -1;
                print("left");
            } else if (Input.GetKey(data.GetKey(3))){
                direction[1] = 1;
                print("Right");
            }
        }
        return direction;
    }
    public void SetDirection(int y,int x){

        if (y != 0 && x != 0){
            animator.SetFloat("xDirection",x);
            animator.SetFloat("yDirection",y);
            if (y == 1 && x == -1){
                transform.rotation = Quaternion.Euler(0, 0, 45);
                moveDirection(0);
                //charicterAnimation. = sprites[0];
            }else if (y == 1 && x == 1){
                transform.rotation = Quaternion.Euler(0, 0, 315);
                moveDirection(0);
                //charicterAnimation.sprite = sprites[1];
            } else if (y == -1 && x == -1){
                transform.rotation = Quaternion.Euler(1, 0, 135);
                moveDirection(2);
                //charicterAnimation.sprite = sprites[2];
            }else if (y == -1 && x == 1){
                transform.rotation = Quaternion.Euler(0, 0, 225);
                moveDirection(2);
                //charicterAnimation.sprite = sprites[3];
            }
        }else if (y == 1){
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetFloat("xDirection",0);
            animator.SetFloat("yDirection",y);
            moveDirection(0);
            //charicterAnimation.sprite = sprites[4];
        }else if (y == -1){
            animator.SetFloat("xDirection",0);
            animator.SetFloat("yDirection",y);
            moveDirection(2);
            transform.rotation = Quaternion.Euler(0, 0, 180);
            //charicterAnimation.sprite = sprites[5];
        }else if (x == -1){
            animator.SetFloat("xDirection",x);
            animator.SetFloat("yDirection",0);
            moveDirection(3);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            //charicterAnimation.sprite = sprites[6];
        }else if (x == 1){
            animator.SetFloat("xDirection",x);
            animator.SetFloat("yDirection",0);
            moveDirection(1);
            transform.rotation = Quaternion.Euler(0, 0, 270);
            //charicterAnimation.sprite = sprites[7];
        }
    }

    void moveDirection(int faceDirection){
        Vector2 movement = rb.linearVelocity;
        if(movement.x != 0 || movement.y != 0){
            switch(faceDirection){
                case 0:
                    animator.SetFloat("forward", movement.y);
                    animator.SetFloat("right", movement.x);
                break;
                case 1:
                    animator.SetFloat("forward", movement.x);
                    animator.SetFloat("right", movement.y);
                break;
                case 2:
                    animator.SetFloat("forward", -movement.y);
                    animator.SetFloat("right", -movement.x);
                break;
                case 3:
                    animator.SetFloat("forward", -movement.x);
                    animator.SetFloat("right", -movement.y);
                break;
            }
        }
    }
}

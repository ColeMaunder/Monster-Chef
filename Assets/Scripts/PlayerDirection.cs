using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerDirectionKey : MonoBehaviour
{


    private PlayerData data;
    
    public SpriteRenderer playerIcon;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
    data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
   }

    // Update is called once per frame
    void Update()
    {
        if (data.GetMouseMovment()){
            SetDirection(DirectionMouse()[0],DirectionMouse()[1]);
        }else{
            SetDirection(DirectionKey()[0],DirectionKey()[1]);
        }
       
    }
    private int[] DirectionMouse(){
        int [] direction = {0,0};
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float positonDiffX = mouseWorldPos.x - transform.position.x;
        //print(positonDiffX);
        float positonDiffY = mouseWorldPos.y - transform.position.y;
        //print(positonDiffY);
        if (positonDiffY > 0){
            direction[0] = 1;
        }else{
            direction[0] = 2;
        }
        if (positonDiffX < 0){
            direction[1] = 1;
        }else{
            direction[1] = 2;
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
                direction[0] = 2;
                print("down");
            }
        }
        if(!Input.GetKey(data.GetKey(2)) || !Input.GetKey(data.GetKey(3))){
            if (Input.GetKey(data.GetKey(2))){
                direction[1] = 1;
                print("left");
            } else if (Input.GetKey(data.GetKey(3))){
                direction[1] = 2;
                print("Right");
            }
        }
        return direction;
    }
    void SetDirection(int y,int x){

        if (y != 0 && x != 0){
            if (y == 1 && x == 1){
                transform.rotation = Quaternion.Euler(0, 0, 45);
                playerIcon.sprite = data.GetSprite(0);
            }else if (y == 1 && x == 2){
                transform.rotation = Quaternion.Euler(0, 0, 315);
                playerIcon.sprite = data.GetSprite(1);
            } else if (y == 2 && x == 1){
                transform.rotation = Quaternion.Euler(1, 0, 135);
                playerIcon.sprite = data.GetSprite(2);
            }else if (y == 2 && x == 2){
                transform.rotation = Quaternion.Euler(0, 0, 225);
                playerIcon.sprite = data.GetSprite(3);
            }
        }else if (y == 1){
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerIcon.sprite = data.GetSprite(4);
        }else if (y == 2){
            transform.rotation = Quaternion.Euler(0, 0, 180);
            playerIcon.sprite = data.GetSprite(5);
        }else if (x == 1){
            transform.rotation = Quaternion.Euler(0, 0, 90);
            playerIcon.sprite = data.GetSprite(6);
        }else if (x == 2){
            transform.rotation = Quaternion.Euler(0, 0, 270);
            playerIcon.sprite = data.GetSprite(7);
        }
    }
}

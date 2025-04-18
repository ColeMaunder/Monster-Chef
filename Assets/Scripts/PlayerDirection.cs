using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerDirectionKey : MonoBehaviour
{


    [HideInInspector] public string[] keys = PlayerData.keys;
    
    public SpriteRenderer playerIcon;
    public Sprite[] sprites = PlayerData.sprites;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerData.movmentMouse){
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
        if(Input.GetKey(keys[0]) || Input.GetKey(keys[1])){
                if (Input.GetKey(keys[0])){
                direction[0] = 1;
                print("up");
            } else if (Input.GetKey(keys[1])){
                direction[0] = 2;
                print("down");
            }
        }
        if(!Input.GetKey(keys[2]) || !Input.GetKey(keys[3])){
            if (Input.GetKey(keys[2])){
                direction[1] = 1;
                print("left");
            } else if (Input.GetKey(keys[3])){
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
                playerIcon.sprite = sprites[0];
            }else if (y == 1 && x == 2){
                transform.rotation = Quaternion.Euler(0, 0, 315);
                playerIcon.sprite = sprites[1];
            } else if (y == 2 && x == 1){
                transform.rotation = Quaternion.Euler(1, 0, 135);
                playerIcon.sprite = sprites[2];
            }else if (y == 2 && x == 2){
                transform.rotation = Quaternion.Euler(0, 0, 225);
                playerIcon.sprite = sprites[3];
            }
        }else if (y == 1){
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerIcon.sprite = sprites[4];
        }else if (y == 2){
            transform.rotation = Quaternion.Euler(0, 0, 180);
            playerIcon.sprite = sprites[5];
        }else if (x == 1){
            transform.rotation = Quaternion.Euler(0, 0, 90);
            playerIcon.sprite = sprites[6];
        }else if (x == 2){
            transform.rotation = Quaternion.Euler(0, 0, 270);
            playerIcon.sprite = sprites[7];
        }
    }
}

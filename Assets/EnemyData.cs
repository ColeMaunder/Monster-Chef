using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private GameObject player;
    public float enemySpeed = 5.0f;
    public float favoredDistance = 0.5f;
    public float agroRaing = 30.0f;
    private bool isAttacking = false;
    private bool canMove = true;
    public Sprite[] sprites = {};
    public GameObject[] enemyList;
    public GameObject getEnemyList(int index){
        return enemyList[index];
    }
    public Sprite[] GetSprites(){
        return sprites;
    }
    
    public EnemyData(){}
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public float GetEnemySpeed(){
        return enemySpeed;
    }
    public float GetFavoredDistance(){
        return favoredDistance;
    }
    public float GetAgroRaing(){
        return agroRaing;
    }

    public bool GetIsAttacking(){
        return isAttacking;
    }

    public void SetIsAttacking(bool isAttackingIn){
        isAttacking = isAttackingIn;
    }

    public bool GetCanMove(){
        return canMove;
    }

    public void SetCanMove(bool canMoveIn){
        canMove= canMoveIn;
    }


    public float PlayerDistance(Rigidbody2D enemy){
        float positonDiffX = player.transform.position.x - enemy.transform.position.x;
        float positonDiffY = player.transform.position.y - enemy.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(positonDiffX, 2) + Mathf.Pow(positonDiffY, 2));
        //print (distance);
        return distance;
    }
}

using System;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private GameObject player;
    
    public int [] maxHealth = {3,0,5};
    public float [] enemySpeed = {3f,0,5f};
    public float [] favoredDistance = {2f,0,10f};
    public float [] agroRaing = {20f,0,20f};

    public Sprite[] slimeSprites = {};
    public Sprite[] mandrakeSprites = {};
    public Sprite[] frogSprites = {};
    public Sprite[] vineSprites = {};
    public GameObject[] enemyList;
    public GameObject[] dropList;

    public GameObject GetEnemyList(int index){
        return enemyList[index];
    }
    public GameObject GetDropList(int index){
        return dropList[index];
    }
    public int GetMaxhealth(int index){
        return maxHealth [index];
    }
    public Sprite[] GetSprites(int enemy){
         switch (enemy){
            case 0:
                return slimeSprites;
            case 1:
                return mandrakeSprites;
            case 2:
                return frogSprites;
            case 3:
                return vineSprites;
            default:
                print ("invalid enemy");
                return null;
        }
    }
    
    public EnemyData(){}
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public float GetEnemySpeed(int enemy){
            return enemySpeed[enemy];
    }
    public float GetFavoredDistance(int enemy){
         return favoredDistance[enemy];
    }
    public float GetAgroRaing(int enemy){
        return agroRaing[enemy];
    }


    public float PlayerDistance(Rigidbody2D enemy){
        float positonDiffX = player.transform.position.x - enemy.transform.position.x;
        float positonDiffY = player.transform.position.y - enemy.transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(positonDiffX, 2) + Mathf.Pow(positonDiffY, 2));
        //print (distance);
        return distance;
    }
}

using System;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private GameObject player;
    
    public int [] maxHealth = {3,0,5};
    public float [] enemySpeed = {3f,0,5f};
    public float [] favoredDistance = {2f,0,10f};
    public float [] agroRaing = {20f,0,20f};
    public AudioClip [] attackSound = { };
    public AudioClip [] hurtSound = { };
    public AudioClip [] deathSound = { };


    public GameObject[] enemyList;
    public GameObject[] dropList;
    
    public void playAttackSound(int index){
        AudioHandler.Instance.playSound(attackSound[index], transform, 1);
    }
    public void playHurtSound(int index){
        AudioHandler.Instance.playSound(hurtSound[index], transform, 1);
    }
    public void playDeathSound(int index){
        AudioHandler.Instance.playSound(deathSound[index], transform, 1);
    }
    public GameObject getEnemyList(int index){
        return enemyList[index];
    }
    public GameObject getDropList(int index){
        return dropList[index];
    }
    public int getMaxhealth(int index){
        return maxHealth [index];
    }
    
    void Start()
    {
        player = GameObject.FindWithTag("PlayerBody");
    }
    public float getEnemySpeed(int enemy){
            return enemySpeed[enemy];
    }
    public float getFavoredDistance(int enemy){
         return favoredDistance[enemy];
    }
    public float getAgroRaing(int enemy){
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

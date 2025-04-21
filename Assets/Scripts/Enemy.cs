using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyData data;
    public int type;
    float health;
    float maxHealth;
    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        maxHealth = data.GetMaxhealth(type);
        health = maxHealth;
    }

    public void damage(float damage){
        health -= damage;
        print(health);
        if(health <= 0){
            print("Enemy dead");
            Instantiate(data.GetDropList(type), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

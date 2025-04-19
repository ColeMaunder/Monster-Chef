using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health,maxHealth = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void damage(float damage){
        health -= damage;
        print(health);
        if(health <= 0){
            print("dead");
            Destroy(gameObject);
        }
    }
}

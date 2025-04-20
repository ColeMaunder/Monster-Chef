using UnityEngine;

public class Player : MonoBehaviour
{
    float health,maxHealth = 10f;
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
        print("curent health is " + health);
        if(health <= 0){
            print("You are Dead");
        }
    }
}

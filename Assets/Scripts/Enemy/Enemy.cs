using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Enemy : MonoBehaviour
{
    EnemyData data;
    public int type;
    float health;
    public float maxHealth = 3f;
    private float duration = 0.1f;
    SpriteRenderer sprite;
    Color colorDefalt;
    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        sprite = this.GetComponent<SpriteRenderer>();
       colorDefalt = sprite.color;
       health = maxHealth;
    }
    private IEnumerator SwitchColorBack(float duration)

{
    sprite.color = new Color(255, 255, 255);
    yield return new WaitForSeconds(duration);
    sprite.color = colorDefalt;
}


    public void Damage(float damage){
        health -= damage;
        print(health);
        StartCoroutine(SwitchColorBack(duration));
        if(health <= 0){
            print("Enemy dead");
            Instantiate(data.GetDropList(type), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

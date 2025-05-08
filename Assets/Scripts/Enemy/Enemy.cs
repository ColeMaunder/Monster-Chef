using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Enemy : MonoBehaviour
{
    EnemyData data;
    public int type;
    float health;
    public float maxHealth = 3f;
    public float duration = 0.2f;
    SpriteRenderer sprite;
    Color colourDefalt;
    public Rigidbody2D enmenyBody;
    public GameObject particleOBJ;
    public float knockBackMutipyer = 1;
    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        sprite = this.GetComponent<SpriteRenderer>();
       colourDefalt = sprite.color;
       health = maxHealth;
    }
    private IEnumerator ResetHitEffects(float duration){
        sprite.color = new Color(255, 255, 255);
        yield return new WaitForSeconds(duration);
        sprite.color = colourDefalt;
        enmenyBody.linearVelocity = Vector2.zero;
    }

    public void Damage(Vector2 weapon, float damage, float knockBack){
        health -= damage;
        Vector2 direction = (enmenyBody.position - weapon).normalized;
        enmenyBody.AddForce(direction * knockBack * knockBackMutipyer,ForceMode2D.Impulse);
        particleOBJ.GetComponent<EnemyHitPartical>().activate(direction);
        StartCoroutine(ResetHitEffects(duration));
        print(health);
        if(health <= 0){
            print("Enemy dead");
            particleOBJ.GetComponent<EnemyHitPartical>().Explode();
            Instantiate(data.GetDropList(type), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

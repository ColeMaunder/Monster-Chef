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
    Collider2D enmenyColider;
    public GameObject particleOBJ;
    public GameObject[] enemyComponents;

    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        sprite = this.GetComponent<SpriteRenderer>();
       colourDefalt = sprite.color;
       health = maxHealth;
    }
    private IEnumerator ResetHitEffects(float duration){
        try{
        sprite.color = new Color(255, 255, 255);
        }catch(MissingReferenceException){}
        yield return new WaitForSeconds(duration);
        try{
        sprite.color = colourDefalt;
        enmenyBody.linearVelocity = Vector2.zero;
        }catch(MissingReferenceException){}
    }


    public void Damage(Vector2 weapon, float damage, float knockBack){
        health -= damage;
        Vector2 direction = (enmenyBody.position - weapon).normalized;
        enmenyBody.AddForce(direction * knockBack,ForceMode2D.Impulse);
        particleOBJ.GetComponent<EnemyHitPartical>().activate(direction);
        StartCoroutine(ResetHitEffects(duration));
        print(health);
        StartCoroutine(death());
    }

    private IEnumerator death(){
        yield return new WaitForSeconds(1f);
        if(health <= 0){
            Destroy(enmenyColider);
            print("Enemy dead");
            Instantiate(data.GetDropList(type), transform.position, Quaternion.identity);
            particleOBJ.GetComponent<EnemyHitPartical>().Explode();
            
            Destroy(sprite);
            foreach(GameObject i in enemyComponents){
                Destroy(i);
            }
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Enemy : MonoBehaviour
{
    EnemyData data;
    EnemyLocalData localData;
    [SerializeField] float health;
    public float duration = 0.1f;
    SpriteRenderer sprite;
    Color colourDefalt;
    public Rigidbody2D enmenyBody;
    public GameObject particleOBJ;
    public float knockBackMutipyer = 1;
    private Material hurtEffect;
    void Start()
    {
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        sprite = this.GetComponent<SpriteRenderer>();
        colourDefalt = sprite.color;
        localData = this.gameObject.gameObject.GetComponent<EnemyLocalData>();
        health = data.getMaxhealth(localData.getEnemyIndex());
        hurtEffect = this.GetComponent<SpriteRenderer>().material;
    }
    private IEnumerator ResetHitEffects(float duration){

        float flashTimePassed = 0f;
        hurtEffect.SetColor("_HitEffectColor", Color.white );
        while (flashTimePassed < duration) {
            flashTimePassed += Time.deltaTime;
             hurtEffect.SetFloat("_HitEfectAmount", Mathf.Lerp(1f, 0f, (flashTimePassed / duration)));
            yield return null;
        }
        enmenyBody.linearVelocity = Vector2.zero;
    }

    public void Damage(Vector2 weapon, float damage, float knockBack){
        if (localData.getVulnrable()){
            health -= damage;
            data.playHurtSound(localData.getEnemyIndex());
            Vector2 direction = (enmenyBody.position - weapon).normalized;
            enmenyBody.AddForce(direction * knockBack * knockBackMutipyer,ForceMode2D.Impulse);
            particleOBJ.GetComponent<EnemyHitPartical>().activate(direction);
            StartCoroutine(ResetHitEffects(duration));
            print(health);
            if(health <= 0){
                data.playDeathSound(localData.getEnemyIndex());
                particleOBJ.GetComponent<EnemyHitPartical>().Explode();
                Instantiate(data.getDropList(localData.getEnemyIndex()), transform.position, Quaternion.identity);
                Destroy(gameObject);
            } 
        }
        
    }
    public int GetHealth(){
        return (int) health;
    }
}

using UnityEngine;
using System.Collections;

public class MandrakeAttack : MonoBehaviour
{
    private EnemyData data  = null;
    private EnemyLocalData dataLocal  = null;
    public float veriance = 1f;
    public float atkCoolDown = 3f;
    public float reactTime = 0.3f;
    public float atkTime = 2f;
    public float atkCheckTime = 0.5f;
    public float atkMissTime = 0.5f;
    private float timer = 0f;
    private Rigidbody2D enmenyBody;
    private Animator animator;
    private bool attacked = false;
    [SerializeField]
    private GameObject hitBox;
    private PlayerData player;

    void Start()
    {
        GameObject enemy = transform.parent.gameObject;
        enmenyBody = enemy.GetComponent<Rigidbody2D>();
        animator = enemy.GetComponent<Animator>();
        dataLocal = enemy.GetComponent<EnemyLocalData>();
        data = GameObject.FindWithTag("EnemyData").GetComponent<EnemyData>();
        player = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        
    }

    // Update is called once per frame
    /*void Update()
    {
        
        if (!dataLocal.getIsAttacking()){
            if (data.PlayerDistance(enmenyBody) < (data.getFavoredDistance(dataLocal.getEnemyIndex()) + veriance)){
                Bite();
            }
        }else{
            
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision){
        StartCoroutine(AttackTimer());
    }

    void Bite(){
        data.playAttackSound(dataLocal.getEnemyIndex());
        attacked = true;
        dataLocal.setCanMove(false);
        animator.SetBool("attackCharged", true);
        animator.SetBool("attack", false);
        hitBox.SetActive(true);
    }
    IEnumerator AttackTimer() {
        if (!dataLocal.getIsAttacking()){
            dataLocal.setIsAttacking(true);

            yield return new WaitForSeconds(reactTime); 

            Bite();

            yield return new WaitForSeconds(atkCheckTime);
            
            if (hitBox.GetComponent<EnemyTrapWeapon>().getHitPlayer()){
                    hitBox.SetActive(false);
                    //start traped animation
                    while (player.getTrapped()){
                        yield return new WaitForSeconds(0.01f);
                    }
                    //end traped animation
                }else{
                    //start miss animation
                    dataLocal.setFullVulnrable(true);
                    yield return new WaitForSeconds(atkMissTime);
                    dataLocal.setFullVulnrable(false);
                    //End miss animation
                    //start hide animation
                yield return new WaitForSeconds(atkMissTime);
                    //end hide animation
                }
                
            dataLocal.setCanMove(true);
            attacked = false;
            hitBox.SetActive(false);

            yield return new WaitForSeconds(atkCoolDown);

            dataLocal.setIsAttacking(false);
        }
         
    }
}


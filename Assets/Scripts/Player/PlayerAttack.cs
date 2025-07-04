using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   public int activeUlt = 0;
   private WeaponAttacks attacks;
    private PlayerData data;
   
   bool isAttacking = false;
   bool isUlting = false;
   float atkTimer = 0f;
   int atkType = 0;
   float heavyCharge=0;
   int lightCombo = 0;
   bool atkSoundPlayed = false;
   Player player;

  Animator animator;

  void Start(){
        attacks = GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
   }
   

    void Update()
    {
        if (Time.timeScale > 0){
             if (player.GetPlayerAlive() && data.GetCanAttack()){
                if (!isAttacking && !isUlting){
                    if (Input.GetMouseButtonDown(0) /*|| Input.GetKeyDown(keys.GetKey(4))*/){
                        heavyCharge=0;
                        if (lightCombo < attacks.GetComboMax()){
                            Attack(0);
                            print("light");
                            lightCombo++;
                            print(lightCombo);
                        }else{
                            Attack(1);
                            lightCombo = 0;
                            print("full light");
                        }
                        
                    } else if (Input.GetMouseButton(1) /*|| Input.GetKeyDown(keys.GetKey(5))*/){
                        lightCombo = 0;
                        heavyCharge = heavyCharge +1 * Time.deltaTime;
                        animator.SetBool("Charging", true);
                        print (heavyCharge);
                        if (heavyCharge > attacks.GetChargeMax()){
                            Attack(4);
                            heavyCharge = 0;
                            print("full light");
                        }
                        
                    }else if(heavyCharge > 0){
                        if(heavyCharge > attacks.GetChargeMax()/2){
                                Attack(3);
                            print("50% heavy");

                        }else{
                            Attack(2);
                            print("uncharged heavy");

                        }
                        heavyCharge = 0;
                    }else if(attacks.GetUltActive()){
                        if(Input.GetKeyDown(KeyCode.Q)) {
                            if (attacks.GetUltCharge() >= attacks.GetUltChargeNeeded(activeUlt)){
                                Ult();
                            }
                        }
                    }
                    
                }else{
                    AttackTimer();
                }
            }else{
                isAttacking = false;
                atkTimer = 0;
                heavyCharge = 0;
                lightCombo = 0;
                attacks.GetAtk(atkType).SetActive(false);
            }
        }
    }
     void Attack(int type){
        animator.SetBool("Charging", false);
        print("attck type" + type);
        animator.SetFloat("AttackType", type);
        animator.SetBool("IsAttacking", true);
        atkType = type;
        isAttacking = true;
        }
        void AttackImpact(){
            attacks.GetAtk(atkType).SetActive(true);
            if (!atkSoundPlayed){
                attacks.playAtkSound(atkType);
                atkSoundPlayed = true;
            }
        }

    void Ult(){
        animator.SetBool("isUlting", true);
        isUlting = true;
            
    }
    void UltImpact(){
        attacks.GetUlt(activeUlt).SetActive(true);
        if (!atkSoundPlayed){
            attacks.PlayUltSound(activeUlt);
            atkSoundPlayed = true;
        }
    }

    
    void AttackTimer(){
        atkTimer += Time.deltaTime;
        float cooldown;
        float duration;
        float warmUp;
        if (isUlting) {
            cooldown = attacks.GetUltCoolDown(activeUlt);
            duration = attacks.GetUltDuration(activeUlt);
            warmUp = attacks.GetUltWarmUp(activeUlt);
        } else {
            cooldown = attacks.GetAtkCoolDown(atkType);
            duration = attacks.GetAtkDuration(atkType);
            warmUp = attacks.GetAtkWarmUp(activeUlt);
        }
        if(atkTimer >= (cooldown + duration + warmUp)){
            if(isUlting){
                attacks.UsedGetUltCharge(activeUlt);
            }
            atkTimer = 0;
            isAttacking = false;
            isUlting = false;
            
        }else if(atkTimer >= (duration + warmUp)){
            attacks.GetAtk(atkType).SetActive(false);
            animator.SetBool("IsAttacking", false);
            animator.SetBool("isUlting", false);
            attacks.GetUlt(activeUlt).SetActive(false);
            atkSoundPlayed = false;
            
        }else if (atkTimer >= warmUp){
            if(isUlting){
                UltImpact();
            }else{
                AttackImpact();
            }
        }
    
    }
}


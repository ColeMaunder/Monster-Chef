using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   public int activeWeapon = 0;
   public int activeUlt = 0;
   private WeaponAttacks attacks;
   private PlayerData keys;
   
   bool isAttacking = false;
   bool isUlting = false;
   float atkTimer = 0f;
   int atkType = 0;
   float heavyCharge=0;
   int lightCombo = 0;
   Player player;
  
  void Start(){
    attacks = GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>();
    keys = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
    player = GameObject.FindWithTag("Player").GetComponent<Player>();
   }
   

    void Update()
    {
        if (player.GetPlayerAlive()){
            AttackTimer();
            if (!isAttacking && !isUlting){
                if (Input.GetMouseButtonDown(0) /*|| Input.GetKeyDown(keys.GetKey(4))*/){
                    heavyCharge=0;
                    if (lightCombo < attacks.GetComboMax(activeWeapon)){
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
                    print (heavyCharge);
                    if (heavyCharge > attacks.GetChargeMax(activeWeapon)){
                        Attack(4);
                        heavyCharge = 0;
                        print("full light");
                    }
                    
                }else if(heavyCharge > 0){
                    if(heavyCharge > attacks.GetChargeMax(activeWeapon)/2){
                            Attack(3);
                        print("50% heavy");

                    }else{
                        Attack(2);
                        print("uncharged heavy");

                    }
                    heavyCharge = 0;
                }else if(attacks.ultActive){
                    if(Input.GetKeyDown(KeyCode.Q)) {
                        if (attacks.GetUltCharge() >= attacks.GetUltChargeNeeded(activeUlt)){
                            Ult();
                        }
                    }
                }
                
            }
        }else{
            isAttacking = false;
            atkTimer = 0;
            heavyCharge = 0;
            lightCombo = 0;
            attacks.GetAtk(activeWeapon,atkType).SetActive(false);
        }
    
    }
     void Attack(int type){
        print("attck type" + type);
            atkType = type;
            isAttacking = true;
            attacks.GetAtk(activeWeapon,type).SetActive(true);
        }

        void Ult(){
            isUlting = true;
            attacks.GetUlt(activeUlt).SetActive(true);
        }
    
    void AttackTimer(){
        atkTimer += Time.deltaTime;
        float cooldown;
        float duration;
        if(isUlting){
            cooldown = attacks.GetUltCoolDown(activeUlt);
            duration = attacks.GetUltDuration(activeUlt);
        }else{
            cooldown = attacks.GetAtkCoolDown(activeWeapon,atkType);
            duration = attacks.GetAtkDuration(activeWeapon,atkType);
        }
        if(atkTimer >= (cooldown + duration)){
            if(isUlting){
                attacks.UsedGetUltCharge(activeUlt);
            }
            atkTimer = 0;
            isAttacking = false;
            isUlting = false;
        }else if(atkTimer >= duration){
            attacks.GetAtk(activeWeapon,atkType).SetActive(false);
            attacks.GetUlt(activeUlt).SetActive(false);
    }
    
}
}


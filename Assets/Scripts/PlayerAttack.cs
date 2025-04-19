using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   public int activeWeapon = 0;
   private WeaponAttacks attacks;
   private PlayerData keys;
   
   bool isAttacking = false;
   float atkTimer = 0f;
   int atkType;
   float heavyCharge=0;
   int lightCombo = 0;
  
  void Start(){
    attacks = GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>();
    keys = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
   }

    void Update()
    {
        AttackTimer();
        if (!isAttacking){
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
            }
            
        }
    
    }
     void Attack(int type){
        print("attck type" + type);
            atkType = type;
            isAttacking = true;
            attacks.GetAtk(activeWeapon,type).SetActive(true);
        }
    
    void AttackTimer(){
        atkTimer += Time.deltaTime;
        if(atkTimer >= attacks.GetAtkDuration(activeWeapon,atkType)){
            atkTimer = 0;
            isAttacking = false;
            attacks.GetAtk(activeWeapon,atkType).SetActive(false);
    }
    
}
}


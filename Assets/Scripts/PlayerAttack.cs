using System.Security.Cryptography;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [HideInInspector] public string[] keys = PlayerData.keys;
   public GameObject[] weponAttack = {};
   bool isAttacking = false;
   float atkDuration = 0.3f;
   float atkTimer = 0f;
   int atkType = 0;
   int heavyCharge=0;
   int lightCombo = 0;
   public int lightComboMax = 3;
  

    // Update is called once per frame
    void Update()
    {
        AttackTimer();
        if (!isAttacking){
            if (Input.GetMouseButtonDown(0) /*|| Input.GetKeyDown(PlayerData.keys[4])*/){
                heavyCharge=0;
                if (lightCombo < lightComboMax){
                    Attack(0);
                    print("light");
                    lightCombo++;
                }else{
                    Attack(1);
                    lightCombo = 0;
                    print("full light");
                }
                
            } //else if (Input.GetMouseButton(1) /*|| Input.GetKeyDown(PlayerData.keys[5])*/){
               // lightCombo = 0;
               // Attack(2);
           // }
        }
    
    }
     void Attack(int type){
        print("attck type" + type);
            atkType = type;
            weponAttack[type].SetActive(true);
            isAttacking = true;
        }
    
    void AttackTimer(){
        atkTimer += Time.deltaTime;
        if(atkTimer >= atkDuration){
            atkTimer = 0;
            isAttacking = false;
            weponAttack[atkType].SetActive(false);
    }
    
}
}


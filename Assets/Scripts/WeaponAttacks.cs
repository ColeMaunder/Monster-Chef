using UnityEngine;

public class WeaponAttacks : MonoBehaviour
{
    public bool cutleryActive;
    public bool ultActive;

    public int spoonComboMax = 2;
    public float spoonChargeMax = 1.5f;
    public GameObject[] spoonAttack = {};
    public float [] spoonAtkDuration = {};
    public float [] spoonAtkCoolDown = {};

    public int cleaverComboMax = 2;
    public float cleaverChargeMax = 1.5f;
    public GameObject[] cleaverAttack = {};
    public float [] cleaverAtkDuration = {};
    public float [] cleaverAtkCoolDown = {};

    public int tenderizerComboMax = 2;
    public float tenderizerChargeMax = 1.5f;
    public GameObject[] tenderizerAttack = {};
    public float [] tenderizerAtkDuration = {};
    public float [] tenderizerAtkCoolDown = {};

    public GameObject[] ults = {};
    public float [] ultDuration = {};
    public float [] ultCoolDown = {};
    public int [] ultChargeNeeded = {};
    public int ultChargeMax;
    private int ultCharge = 0;

    public WeaponAttacks(){}

    public void SetCutleryActive(bool input){
        cutleryActive = input;
    }
    public void SetUltActive(bool input){
        ultActive = input;
    }

    public bool GetCutleryActive(){
        return cutleryActive;
    }
    public bool GetUltActive(){
        return ultActive;
    }
    
    public GameObject GetUlt(int index){
        return ults[index];
    }
    public float GetUltDuration(int index){
        return ultDuration[index];
    }
    public float GetUltCoolDown(int index){
        return ultCoolDown[index];
    }
    public int GetUltChargeNeeded(int index){
        return ultChargeNeeded[index];
    }
    public int GetUltChargeMax(){
        return ultChargeMax;
    }
    public void SetUltCharge(int ultChargeIn){
        ultCharge = ultChargeIn;
    }
    public int GetUltCharge(){
        return ultCharge;
    }
    public int UsedGetUltCharge(int index){
        ultCharge = ultCharge - ultChargeNeeded[index];
        print ("ult charge is " + ultCharge);
        return ultCharge;
    }
    public int IncGetUltCharge(){
        if (ultCharge < ultChargeMax){
            ultCharge++;
            print ("ult charge is " + ultCharge);
            return ultCharge;
        }else{
            print ("ult charge is" + ultChargeMax);
            return ultChargeMax;
        }
        
        
    }

    public float GetChargeMax(int weapon){
        switch(weapon){
            case 0:
                return spoonChargeMax;
            case 1:
                return cleaverChargeMax;
            case 2:
                return tenderizerChargeMax;
            default:
                print("invalid Weapon");
                return 0;
        }
    }

    public int GetComboMax(int weapon){
        switch(weapon){
            case 0:
                return spoonComboMax;
            case 1:
                return cleaverComboMax;
            case 2:
                return tenderizerComboMax;
            default:
                print("invalid Weapon");
                return 0;
        }
    }
    
    public GameObject GetAtk(int weapon, int atk){
        switch(weapon){
            case 0:
                return spoonAttack[atk];
            case 1:
                return cleaverAttack[atk];
            case 2:
                return tenderizerAttack[atk];
            default:
                print("invalid Weapon");
                return null;
        }
    }

    public float GetAtkDuration(int weapon, int atk){
        switch(weapon){
            case 0:
                return spoonAtkDuration[atk];
            case 1:
                return cleaverAtkDuration[atk];
            case 2:
                return tenderizerAtkDuration[atk];
            default:
                print("invalid Weapon");
                return 0;
        }
    }
    public float GetAtkCoolDown(int weapon, int atk){
        switch(weapon){
            case 0:
                return spoonAtkCoolDown[atk];
            case 1:
                return cleaverAtkCoolDown[atk];
            case 2:
                return tenderizerAtkCoolDown[atk];
            default:
                print("invalid Weapon");
                return 0;
        }
    }
}

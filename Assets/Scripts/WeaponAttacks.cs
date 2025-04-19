using UnityEngine;

public class WeaponAttacks : MonoBehaviour
{
    public int spoonComboMax = 2;
    public float spoonChargeMax = 1.5f;
    public GameObject[] spoonAttack = {};
    public float [] spoonAtkDuration = {};

    public int cleaverComboMax = 2;
    public float cleaverChargeMax = 1.5f;
    public GameObject[] cleaverAttack = {};
    public float [] cleaverAtkDuration = {};

    public int tenderizerComboMax = 2;
    public float tenderizerChargeMax = 1.5f;
    public GameObject[] tenderizerAttack = {};
    public float [] tenderizerAtkDuration = {};

    public WeaponAttacks()
    {}

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
}

using UnityEngine;

public class TutoralUnlocks : MonoBehaviour
{
    WeaponAttacks attacks;
    void Start()
    {
        attacks = GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class MapFountain : MonoBehaviour
{
    [SerializeField] string ariaID;
    void OnEnable(){
        if (!GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>().CheckAria(ariaID)){
                transform.gameObject.SetActive(false);
        } 
    }
}

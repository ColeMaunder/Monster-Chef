using UnityEngine;

public class MapFountain : MonoBehaviour
{
    [SerializeField] string iD;
    [SerializeField] bool aria = false;
    void OnEnable(){
        if(aria){
          if (!GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>().CheckAria(iD)){
                transform.gameObject.SetActive(false);
            }   
        }else{
            if (!GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>().CheckFountain(iD)){
                transform.gameObject.SetActive(false);
            }  
        }
        
    }
}

using UnityEngine;

public class UnlockFountain : MonoBehaviour
{
    PlayerData data;
    public string [] ids;
    void Start()
    {
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        foreach (string i in ids){
            if (!data.CheckFountain(i)){
                data.UnlockFountain(i);
                break;
            }
        }
        
    }
}

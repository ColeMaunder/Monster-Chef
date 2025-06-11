using UnityEngine;

public class MapIcon : MonoBehaviour
{
    public GameObject[] fountins;
    private PlayerData data;
    void OnEnable()
    {
        for(int i = 0;i < fountins.Length; i++){
            data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
            fountins[i].SetActive(true);
        }
    }
}

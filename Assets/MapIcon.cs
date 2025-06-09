using UnityEngine;

public class MapIcon : MonoBehaviour
{
    public GameObject[] fountins;
    private PlayerData data;
    void OnEnable()
    {
        for(int i = 0;i <= 3; i++){
            data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
            fountins[i].SetActive(data.GetFountain(i));
        }
    }
}

using UnityEngine;

public class SceneConfiger : MonoBehaviour
{
    [SerializeField]
     float timeScale = 1f;
     [SerializeField]
     float musicVolume = 1f;
     [SerializeField]
     int sceneCahngeID = 0;
    [SerializeField]
    Player player;
    [SerializeField]
    bool staticCamra = false;
    [SerializeField]
    float[] camPoition = { 0, 0, -10 };
    [SerializeField]
    private bool safe = false;
    [SerializeField]
    private bool hasPlayer = true;
    [SerializeField]
    private bool PlayerLightOn = true;
    [SerializeField]
    private AudioClip seaneMusic;
    void Awake()
    {
        Time.timeScale = timeScale;
        GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>().SetCahingID(sceneCahngeID);
        GameObject.FindWithTag("UI").GetComponent<MenuHandler>().setCombatUIActive(!safe);
        GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>().FaidInWorldSound(seaneMusic,musicVolume,1f,0);
        GameObject.FindWithTag("SoundManager").GetComponent<AudioSource>().Play();
        GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().SetCamraMove(!staticCamra);
        if (staticCamra) {
            GameObject.FindWithTag("MainCamera").transform.position =  new Vector3( camPoition[0], camPoition[1],camPoition[2]);
        }else{
            GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().SetFolowPlayer(true);
        }
        if (hasPlayer)
            {
                GameObject.FindWithTag("UI").GetComponent<MenuHandler>().setInventoryActive(true);
                player = GameObject.FindWithTag("Player").GetComponent<Player>();
                GameObject.FindWithTag("Player").transform.GetChild(4).gameObject.SetActive(PlayerLightOn);
                player.UpdateAll();
                player.ToStart();
            }
            else
            {
                //Time.timeScale = 0;
                GameObject.FindWithTag("UI").GetComponent<MenuHandler>().setInventoryActive(false);
            }
        
    }
    
}

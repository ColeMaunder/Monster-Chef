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
        AudioHandler sound = GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>();
        GameObject camraOBJ = GameObject.FindWithTag("MainCamera");
        MenuHandler menue = GameObject.FindWithTag("UI").GetComponent<MenuHandler>();
        CameraFollow camra = camraOBJ.GetComponent<CameraFollow>();
        PlayerData data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>().SetCahingID(sceneCahngeID);
        data.SetNaturalSceneCahngeID(sceneCahngeID);
        data.SetSceneMusic(seaneMusic);
        menue.setCombatUIActive(!safe);
        data.SetCanAttack(!safe);
        sound.FaidBetweenWorldSound(seaneMusic,musicVolume,8f,0);
        sound.GetComponent<AudioSource>().Play();
        camra.SetCamraMove(!staticCamra);
        if (staticCamra) {
            camraOBJ.transform.position =  new Vector3( camPoition[0], camPoition[1],camPoition[2]);
        }else{
            camra.SetFolowPlayer(true);
        }
        if (hasPlayer)
            {
                menue.setInventoryActive(true);
                player = GameObject.FindWithTag("Player").GetComponent<Player>();
                GameObject.FindWithTag("Player").transform.GetChild(4).gameObject.SetActive(PlayerLightOn);
                player.UpdateAll();
                player.ToStart();
            }
            else
            {
                //Time.timeScale = 0;
                menue.setInventoryActive(false);
            }
        
    }
    
}

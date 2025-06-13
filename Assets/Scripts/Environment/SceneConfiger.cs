using UnityEngine;

public class SceneConfiger : MonoBehaviour
{
    Player player;
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
        Time.timeScale = 1f;
        GameObject.FindWithTag("UI").GetComponent<MenuHandler>().setCombatUIActive(!safe);
        GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>().setMusic(seaneMusic);
        GameObject.FindWithTag("SoundManager").GetComponent<AudioSource>().Play();
        
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

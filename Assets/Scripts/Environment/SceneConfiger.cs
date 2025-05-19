using UnityEngine;

public class SceneConfiger : MonoBehaviour
{
    Player player;
    public AudioClip sceaneMusic;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.UpdateAll();
        player.Respawn();
        GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>().setMusic(sceaneMusic);
        GameObject.FindWithTag("SoundManager").GetComponent<AudioSource>().Play();
    }
    
}

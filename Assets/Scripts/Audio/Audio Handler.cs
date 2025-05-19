using UnityEngine;


public class AudioHandler : MonoBehaviour
{
    public static AudioHandler Instance;
    [SerializeField]
    private AudioSource sound;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void playSound(AudioClip audioClip, Transform position, float volume){
        AudioSource audioSource = Instantiate(sound, position.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource.gameObject,audioSource.clip.length);
    }
    
    public void playRandomSound(AudioClip[] audioClip, Transform position, float volume){
        AudioSource audioSource = Instantiate(sound, position.position, Quaternion.identity);
        int rand = Random.Range(0, audioClip.Length);
        audioSource.clip = audioClip[rand];
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource.gameObject,audioSource.clip.length);
    }
    public void setMusic(AudioClip audioClip){
        AudioSource music = this.GetComponent<AudioSource>();
        music. clip = audioClip;
    }
        
}

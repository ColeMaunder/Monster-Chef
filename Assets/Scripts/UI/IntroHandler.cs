using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class IntroHandler : MonoBehaviour
{
    [SerializeField] VideoClip[] secnes;
    [SerializeField] AudioClip[] music;
    [SerializeField] GameObject continueOBj;
    [SerializeField] string nextScene = "Start Tut Block";
    VideoPlayer player;
    AudioHandler musicPlayer;
    bool playNext = true;

    void Start()
    {
        musicPlayer = GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>();
        player = gameObject.GetComponent<VideoPlayer>();
        StartCoroutine(Intro());
    }
    IEnumerator Intro()
    {
        playNext = false;
        player.clip = secnes[0];
        player.playbackSpeed = 1;
        player.Play();
        float videoTime = (float)secnes[0].length;
        yield return new WaitForSecondsRealtime(videoTime -3f);
        musicPlayer.setSoundEffect(music[1],1);
        player.clip = secnes[1];
        player.playbackSpeed = 2.5f;
        player.Play();
        videoTime = (float)secnes[1].length;
        yield return new WaitForSecondsRealtime(videoTime /2.5f-0.5f);
        musicPlayer. WorldSoundOn(false,1);
        continueOBj.SetActive(true);
        while (!playNext) { yield return new WaitForSecondsRealtime(0.01f);}
        musicPlayer.FaideOutWorldSound(8f,0);
        playNext = false;
        player.clip = secnes[2];
        player.playbackSpeed = 1f;
        player.Play();
        videoTime = (float)secnes[2].length;
        yield return new WaitForSecondsRealtime(videoTime-0.1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
    public void Continue() {
        playNext = true;
        continueOBj.SetActive(false);
    }
    void Update(){
        if(continueOBj.activeSelf){
            if (Input.GetKeyDown(KeyCode.Space)){
                Continue();
            }        
        }
    }
}

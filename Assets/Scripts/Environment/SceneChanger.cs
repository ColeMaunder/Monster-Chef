using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] VideoClip[] videos;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] int chaingeID;
    private PlayerStorage storage;
    GameObject vidPlayerOBJ;
    VideoPlayer vidPlayer;
    AudioHandler sound;
    void Awake()
    {
        sound = GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>();
        vidPlayerOBJ = transform.GetChild(0).gameObject;
        vidPlayer = gameObject.GetComponent<VideoPlayer>();
    }
    public void GoToScene(string sceneName)
    {
        //storage.Save();
        StartCoroutine(SceneChaing(sceneName));
    }
    IEnumerator SceneChaing(string sceneName)
    {
        vidPlayer.clip = videos[chaingeID];
        sound.WorldSoundOn(false, 0);
        sound.SetLoop(false);
        sound.setSoundEffect(sounds[chaingeID],1);
        vidPlayer.playbackSpeed = 1;
        vidPlayer.Play();
        yield return new WaitForSecondsRealtime(0.1f);
        vidPlayerOBJ.SetActive(true);
        float videoTime = (float)videos[chaingeID].length;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        yield return new WaitForSecondsRealtime(videoTime);
        vidPlayerOBJ.SetActive(false);
        sound.SetLoop(true);
        sound.WorldSoundOn(false, 1);
        vidPlayer.Stop();
    }
    public void OnlySceneChaing(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void DieToScene(string sceneName)
    {
        //storage.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void Stay()
    {
        //storage.Save();
        StartCoroutine(Anaimtion());
    }
    IEnumerator Anaimtion()
    {
        vidPlayer.clip = videos[chaingeID];
        sound.WorldSoundOn(false, 0);
        sound.SetLoop(false);
        sound.setSoundEffect(sounds[chaingeID],1);
        vidPlayer.playbackSpeed = 1;
        vidPlayer.Play();
        yield return new WaitForSecondsRealtime(0.1f);
        vidPlayerOBJ.SetActive(true);
        float videoTime = (float)videos[chaingeID].length;
        yield return new WaitForSecondsRealtime(videoTime);
        vidPlayerOBJ.SetActive(false);
        sound.SetLoop(true);
        sound.WorldSoundOn(false, 1);
        vidPlayer.Stop();
    }
    public void SetCahingID(int idIn){
        chaingeID = idIn;
    }
}

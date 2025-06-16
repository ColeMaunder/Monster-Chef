using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] VideoClip[] videos;
    [SerializeField] int chaingeID;
    private PlayerStorage storage;
    GameObject vidPlayerOBJ;
    VideoPlayer vidPlayer;
    void Awake()
    {
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
        vidPlayer.playbackSpeed = 1;
        vidPlayer.Play();
        yield return new WaitForSecondsRealtime(0.1f);
        vidPlayerOBJ.SetActive(true);
        float videoTime = (float)videos[chaingeID].length;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        yield return new WaitForSecondsRealtime(videoTime);
        vidPlayerOBJ.SetActive(false);
        vidPlayer.Stop();
    }
    public void Stay()
    {
        //storage.Save();
        StartCoroutine(Anaimtion());
    }
    IEnumerator Anaimtion()
    {
        vidPlayer.clip = videos[chaingeID];
        vidPlayer.playbackSpeed = 1;
        vidPlayer.Play();
        yield return new WaitForSecondsRealtime(0.1f);
        vidPlayerOBJ.SetActive(true);
        float videoTime = (float)videos[chaingeID].length;
        yield return new WaitForSecondsRealtime(videoTime);
        vidPlayerOBJ.SetActive(false);
        vidPlayer.Stop();
    }
    public void SetCahingID(int idIn){
        chaingeID = idIn;
    }
}

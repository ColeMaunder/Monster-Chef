using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class PlayLetter : MonoBehaviour
{
    [SerializeField] GameObject vidoOBJ;
    [SerializeField] GameObject nextButton;
    VideoPlayer video;
    bool go;
    void Start()
    {
        video = transform.parent.parent.gameObject.GetComponent<VideoPlayer>();
    }

    void Update(){
        if(nextButton.activeSelf){
            if (Input.GetKeyDown(KeyCode.E)){
                ShuldGo();
            }  
        }
        
    }
    void OnTriggerEnter2D()
    {
        StartCoroutine(Letter());
    }
    IEnumerator Letter()
    {
        Time.timeScale = 0;
        float videoTime = (float)video.clip.length;
        video.playbackSpeed = 1.5f;
        video.Play();
        yield return new WaitForSecondsRealtime(0.1f);
        vidoOBJ.SetActive(true);
        yield return new WaitForSecondsRealtime(videoTime/4);
        video.Pause();
        nextButton.SetActive(true);
        while (!go){
            yield return new WaitForSecondsRealtime(0.1f);
        }
        video.Stop();
        vidoOBJ.SetActive(false);
        transform.parent.parent.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ShuldGo(){
        go = true;
        nextButton.SetActive(false);
    }
}

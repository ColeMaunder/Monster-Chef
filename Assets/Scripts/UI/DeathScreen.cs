using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] GameObject [] buttons;
    void OnEnable()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        StartCoroutine(death());
    }

    IEnumerator death()
    {
        VideoClip video = gameObject.GetComponent<VideoPlayer>().clip;
        float videoTime = (float)video.length;
        yield return new WaitForSecondsRealtime(videoTime);
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
    }
}

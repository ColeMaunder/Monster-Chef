using System.Collections;
using UnityEngine;

public class FountainHandler : MonoBehaviour
{
    public GameObject MapScreen;
    public GameObject[] AriaMaps;
    public GameObject MainScreen;



    public void ShowMapScreen(bool activeIn)
    {
        MapScreen.SetActive(activeIn);
    }
    public void ShoAriaMapActive(int index)
    {
        AriaMaps[index].SetActive(true);
    }
    public void ShoAriaMapInactive(int index)
    {
        AriaMaps[index].SetActive(false);
    }
    public void ShowMainScreen(bool activeIn)
    {
        MainScreen.SetActive(activeIn);
    }
    public void CloseFountin(){
        StartCoroutine(closeWate());
    }

    IEnumerator closeWate(){
        yield return new WaitForSecondsRealtime(0.1f);
        for (int i = 0; i < 5; i++){
            transform.GetChild(i).gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

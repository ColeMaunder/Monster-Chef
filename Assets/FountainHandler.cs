using System;
using Unity.VisualScripting;
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
    public void CloseFountin()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

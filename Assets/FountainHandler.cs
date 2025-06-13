using Unity.VisualScripting;
using UnityEngine;

public class FountainHandler : MonoBehaviour
{
    public GameObject MapScreen;

    public GameObject MainScreen;


    
    public void ShowMapScreen(bool activeIn)
    {
        MapScreen.SetActive(activeIn);
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

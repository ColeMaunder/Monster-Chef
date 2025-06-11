using Unity.VisualScripting;
using UnityEngine;

public class FountainHandler : MonoBehaviour
{
    public GameObject MapScreen;
    public GameObject MenueScreen;
    public GameObject InventoryScreen;
    public GameObject MainScreen;


    public void ShowMenueScreen(bool activeIn)
    {
        MenueScreen.SetActive(activeIn);
    }
    public void ShowWeponScreen(bool activeIn)
    {
        InventoryScreen.SetActive(activeIn);
    }
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
    }
}

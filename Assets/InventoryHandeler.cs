using UnityEngine;

public class InventoryHandeler : MonoBehaviour
{
    public GameObject MainScreen;
    public GameObject MenueScreen;
    public GameObject InventoryScreen;
    public void ShowMenueScreen(bool activeIn)
    {
        MenueScreen.SetActive(activeIn);
    }
    public void ShowWeponScreen(bool activeIn)
    {
        InventoryScreen.SetActive(activeIn);
    }
    public void CloseInventory()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ShowMainScreen(bool activeIn)
    {
        MainScreen.SetActive(activeIn);
    }
}

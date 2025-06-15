using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject settingsScreen;
    public GameObject deathScreen;
    public GameObject cobatUI;
    public GameObject inventoryUI;
    public GameObject inventoryScreen;
    private Player player;

    void Update()
    {
        if (Time.timeScale > 0){
            // Check for input to pause the game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseScreen.SetActive(true);
                pauseScreen.transform.GetChild(0).gameObject.SetActive(true);
                Time.timeScale = 0f; // Pause the game
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventoryScreen.SetActive(true);
                inventoryScreen.transform.GetChild(0).gameObject.SetActive(true);
                Time.timeScale = 0f; // Pause the game
            }
        }

    }
    //Pause screen Functions
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        Time.timeScale = 1f; // Unpaused
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void openSetings()
    {
        settingsScreen.SetActive(true);
    }
    public void closeSetings()
    {
        settingsScreen.SetActive(false);
    }

    public void showDeathScreen(bool activeIn)
    {
        deathScreen.SetActive(activeIn);
    }
    public void setCombatUIActive(bool activeIn)
    {
        cobatUI.SetActive(activeIn);
    }
    public void setInventoryActive(bool activeIn){
        inventoryUI.SetActive(activeIn);
    }
     public void setInventoryScreenActive(bool activeIn){
        inventoryScreen.SetActive(activeIn);
    }
    public void respawnUI()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().Respawn();
    }
}


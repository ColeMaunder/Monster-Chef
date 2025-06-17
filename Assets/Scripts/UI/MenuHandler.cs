using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject settingsScreen;
    public GameObject deathScreen;
    public GameObject cobatUI;
    public GameObject inventoryUI;
    public GameObject inventoryScreen;
    public AudioClip menueMusic;
    private Player player;
    AudioHandler music;
    void Start()
    {
        music = GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>();
        pauseScreen.SetActive(false);
        inventoryScreen.SetActive(false);
    }
    void Update()
    {
        if (Time.timeScale > 0)
        {
            // Check for input to pause the game
            if (Input.GetKeyDown(KeyCode.Escape)){
                pauseScreen.SetActive(true);
                pauseScreen.transform.GetChild(0).gameObject.SetActive(true);
                music.FaidBetweenWorldSound(menueMusic, 1, 5, 0);
                Time.timeScale = 0f; // Pause the game
            }else if (Input.GetKeyDown(KeyCode.I)){
                setInventoryScreenActive(true);
            }
        }

    }
    //Pause screen Functions
    public void Resume()
    {
        Time.timeScale = 1f;
        GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>().FaidBetweenWorldSound
                (GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>().GetSceneMusic(), 1, 10, 0);
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
    public void setInventoryActive(bool activeIn)
    {
        inventoryUI.SetActive(activeIn);
    }
    public void setInventoryScreenActive(bool activeIn)
    {
        Time.timeScale = 0f; // Pause the game
        music.FaidBetweenWorldSound(menueMusic, 1, 10, 0);
        inventoryScreen.SetActive(activeIn);
        inventoryScreen.transform.GetChild(0).gameObject.SetActive(activeIn);
    }
    public void respawnUI()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().Respawn();
    }
}


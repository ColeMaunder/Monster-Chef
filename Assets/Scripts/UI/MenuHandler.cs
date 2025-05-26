using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject settingsScreen;
    public GameObject deathScreen;
    public GameObject cobatUI;
    public GameObject inventory;
    private Player player;

    void Update()
    {
        // Check for input to pause the game
        if (Input.GetKey(KeyCode.Escape))
        {
            //try{
            pauseScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
            //}catch(UnassignedReferenceException){}
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
        inventory.SetActive(activeIn);
    }
    public void respawnUI(){
        GameObject.FindWithTag("Player").GetComponent<Player>().Respawn();
    }
}


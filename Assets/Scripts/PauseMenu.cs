using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    void Update()
    {
        // Check for input to pause the game
        if (Input.GetKey(KeyCode.Escape)){
            pauseScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
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
}

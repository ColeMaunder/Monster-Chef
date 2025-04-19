using UnityEngine;

public class TitleScreen : MonoBehaviour
{
   public void GoToScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        // Uncomment the following line to quit the game when running in a built application
        /* Application.Quit();
         Debug.Log("Game is quitting");
        */

        // For testing in the editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }
}

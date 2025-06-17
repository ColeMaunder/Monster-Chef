using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    SceneChanger scene;
    void Start()
    {
        scene = GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>();
    }
    public void GoToScene(string sceneName)
    {
        scene.OnlySceneChaing(sceneName);
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

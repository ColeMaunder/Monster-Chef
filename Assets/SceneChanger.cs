using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string SceneTo;
    void OnTriggerEnter2D(Collider2D trigger){
        if (trigger.gameObject.tag == "Player"){
            GoToScene(SceneTo);
        }
    }

    public void GoToScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

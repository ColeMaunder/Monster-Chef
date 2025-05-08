using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    private Player player;
    public string SceneTo;
    void OnTriggerEnter2D(Collider2D trigger){
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (trigger.gameObject.tag == "Player"){
            player.WipeAll();
            GoToScene(SceneTo);
        }
    }

    public void GoToScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

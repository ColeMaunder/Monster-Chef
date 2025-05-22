using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    private PlayerStorage storage;
    private Player player;
    public string SceneTo;
    void OnTriggerEnter2D(Collider2D trigger){
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        storage = GameObject.FindWithTag("StorageHandeler").GetComponent<PlayerStorage>();
        if (trigger.gameObject.tag == "Player")
        {
            player.WipeAll();
            GoToScene(SceneTo);
        }
    }

    public void GoToScene(string sceneName)
    {
        storage.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    private Player player;
    public string SceneTo;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D trigger){
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

using UnityEngine;

public class End : MonoBehaviour
{
    public string SceneTo;
    SceneChanger scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scene = GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>();
    }

    void OnTriggerEnter2D(Collider2D trigger){
        print("Fuck");
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
//        storage = GameObject.FindWithTag("StorageHandeler").GetComponent<PlayerStorage>();
        if (trigger.gameObject.tag == "Player"){
            player.WipeAll();
            scene.GoToScene(SceneTo);
        }
    }
}

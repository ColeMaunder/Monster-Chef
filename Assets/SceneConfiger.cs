using UnityEngine;

public class SceneConfiger : MonoBehaviour
{
    Transform playerPosition;
    Player player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.UpdateAll();
        player.Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

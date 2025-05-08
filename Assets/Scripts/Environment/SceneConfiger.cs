using UnityEngine;

public class SceneConfiger : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.UpdateAll();
        player.Respawn();
    }
    
}

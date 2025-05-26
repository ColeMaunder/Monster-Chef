using UnityEngine;

public class SceneConfiger : MonoBehaviour
{
    Player player;
    [SerializeField]
    private bool safe = false;
    void Start()
    {
        GameObject.FindWithTag("UI").GetComponent<MenuHandler>().setCombatUIActive(!safe);
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.UpdateAll();
        player.Respawn();
    }
    
}

using Unity.VisualScripting;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    Player player;
    GameObject lastRespawn;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.E)){ 
        player.RefillHeals();
        player.RefillHealth();
        GameObject Respawn = GameObject.FindWithTag("Respawn");
        Respawn.transform.position = transform.position;
       }
    }
}

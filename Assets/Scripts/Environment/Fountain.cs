using Unity.VisualScripting;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    Player player;
    GameObject lastRespawn;
    bool inRainge = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inRainge){
            if (Input.GetKeyDown(KeyCode.E)){ 
                player.RefillHeals();
                player.RefillHealth();
                GameObject Respawn = GameObject.FindWithTag("Respawn");
                Respawn.transform.position = transform.position;
                print("fountain set");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            print("player in");
            inRainge = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            inRainge = false;
        }
    }
}

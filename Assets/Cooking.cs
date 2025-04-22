using UnityEngine;

public class Cooking : MonoBehaviour
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
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            inRainge = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            inRainge = false;
        }
    }
}

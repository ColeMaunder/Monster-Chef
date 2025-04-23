using UnityEngine;

public class Cooking : MonoBehaviour
{
    bool cooked =  false;
    Player player;
    public float newMaxHealth = 30f;
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
                if(!cooked){
                    cooked = true;
                    print("health up");
                    player.SetMaxHealth(newMaxHealth);
                    player.HealthFull();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            print("in");
            inRainge = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            inRainge = false;
        }
    }
}

using UnityEngine;

public class Cooking : MonoBehaviour
{
    bool cooked =  false;
    Player player;
    PlayerInventory inventory;
    PlayerData data;
    public float newMaxHealth = 30f;
    bool inRainge = false;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        
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
    public void CookRecipe(int recipeIndex){
        if (inventory.Contains(recipeIndex)){
            inventory.Reduce(recipeIndex);
            data.SetUnlockedRecipe(recipeIndex,true);
        }
        
    }
}

using UnityEngine;
using System.Collections;

public class Cooking : MonoBehaviour
{
    bool cooked = false;
    Player player;
    PlayerInventory inventory;
    PlayerData data;
    public float newMaxHealth = 30f;
    bool inRainge = false;
    /*public GameObject cookobj;
    public GameObject recepieScreen;
    public GameObject cookingScreen;
    public GameObject DoneScreen;*/

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inRainge)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //CookRecipe(1);
                if (!cooked)
                {
                    print("health up");
        player.SetMaxHealth(newMaxHealth);
        player.HealthFull();/*
                    cooked = true;
                    cookobj.SetActive(true);
                    recepieScreen.SetActive(true);
                    cookingScreen.SetActive(true);
                    */
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("in");
            inRainge = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRainge = false;
        }
    }
    /*
    public void CookRecipe(int recipeIndex)
    {
        if (inventory.Contains(recipeIndex) && !data.GetUnlockedRecipe(recipeIndex))
        {
            cooked = true;
            inventory.Reduce(recipeIndex);
            data.SetUnlockedRecipe(recipeIndex, true);
        }

    }
    public void startCook(){
        StartCoroutine(Cook());
    }
    IEnumerator Cook()
    {
        recepieScreen.SetActive(false);
        yield return new WaitForSeconds(1f);
        cookingScreen.SetActive(false);
        yield return new WaitForSeconds(1f);
        DoneScreen.SetActive(false);
        cookobj.SetActive(true);
        
    }*/
}

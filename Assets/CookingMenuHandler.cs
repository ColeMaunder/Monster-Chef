using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CookingMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject[] recepies;
    [SerializeField] GameObject book;
    private int[] visibalRecepies = { 0, 1, 2 };
    private PlayerInventory inventory;
    RecipeData recipe;
    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        recipe = GameObject.FindWithTag("PlayerData").GetComponent<RecipeData>();
    }
    void OnEnable()
    {
        PageSetup();
    }
    private void PageSetup()
    {
        CheckAll();
        

    }
    private void CheckAll()
    {
        for (int i = 0; i <= 2; i++)
        {
            Check(visibalRecepies[i], i);
            recepies[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = recipe.Icon(visibalRecepies[i]);
            recepies[i].transform.GetChild(2).gameObject.GetComponent<TextMeshPro>().text = recipe.Names(visibalRecepies[i]);
            recepies[i].transform.GetChild(3).gameObject.GetComponent<TextMeshPro>().text = recipe.Texts(visibalRecepies[i]);
        }
    }
    private void Check(int index, int button)
    {
        if (inventory.Contains(index))
        {
            recepies[button].transform.GetChild(1).gameObject.SetActive(true);
            recepies[button].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = recipe.Icon(index);
        }
        else
        {
            recepies[button].transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public void ChangePage(bool next)
    {
         for (int i = 0; i <= 2; i++) {
            if (next){
                visibalRecepies[i] += 3;
            } else {
                visibalRecepies[i] -= 3;
            } 
        }
        PageSetup();
    }
    public void StartCook(int index)
    {
        book.SetActive(false);
        inventory.Reduce(visibalRecepies[index]);
        recipe.UnlockedRecipe(visibalRecepies[index]);
    }
    
}

using Unity.VisualScripting;
using UnityEngine;

public class UpGrades : MonoBehaviour
{
    [SerializeField] float newMaxHealth= 30;
    private HealsUI heals;
    private HealsManger bar;
    RecipeData data;
    void Start()
    {
        data = transform.GetChild(0).GetChild(0).gameObject.GetComponent<RecipeData>();
        heals = GameObject.FindWithTag("UI").transform.GetChild(0).GetChild(1).gameObject.GetComponent<HealsUI>();
        bar = GameObject.FindWithTag("UI").transform.GetChild(0).GetChild(2).gameObject.GetComponent<HealsManger>();
    }
    void Update()
    {
        if (data.GetUnlockedRecipe(0))
        {
            gameObject.GetComponent<Player>().SetMaxHeals(4);
            heals.addPotion(0);
        }
        if (data.GetUnlockedRecipe(1)){
            gameObject.GetComponent<Player>().SetMaxHealth(newMaxHealth);
            bar.swapHealBar(0);
        }
    }
}

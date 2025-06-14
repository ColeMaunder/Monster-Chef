using Unity.VisualScripting;
using UnityEngine;

public class UpGrades : MonoBehaviour
{
    [SerializeField] float newMaxHealth;
    GameObject[] newHeal;
    private HealsUI heals;
    private HealsManger bar;
    RecipeData data;
    void Start()
    {
        newHeal[0] = GameObject.FindWithTag("UI").transform.GetChild(0).GetChild(1).GetChild(1).GetChild(3).gameObject;
        newHeal[1] = GameObject.FindWithTag("UI").transform.GetChild(0).GetChild(1).GetChild(0).GetChild(3).gameObject;
        data = transform.GetChild(0).GetChild(0).gameObject.GetComponent<RecipeData>();
        heals = GameObject.FindWithTag("UI").transform.GetChild(0).GetChild(1).gameObject.GetComponent<HealsUI>();
        bar = GameObject.FindWithTag("UI").transform.GetChild(0).GetChild(2).gameObject.GetComponent<HealsManger>();
    }
    void Update()
    {
        if (data.GetUnlockedRecipe(0))
        {
            gameObject.GetComponent<Player>().SetMaxHeals(4);
            heals.addPotion(newHeal[0]);
            newHeal[1].SetActive(true);
            newHeal[0].SetActive(true);
        }
        if (data.GetUnlockedRecipe(1)){
            gameObject.GetComponent<Player>().SetMaxHealth(newMaxHealth);
            bar.swapHealBar(true);
        }else{
            bar.swapHealBar(false);
        }
    }
}

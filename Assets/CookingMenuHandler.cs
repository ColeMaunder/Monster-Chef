using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Video;
using System.Collections;
public class CookingMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject book;
    [SerializeField] GameObject cookButton;
    [SerializeField] GameObject ReturnButton;
    [SerializeField] GameObject cookVideoObj;
    public TMP_Text[] counts;
    public GameObject[] icons;
    private int visibalRecepie = 0;
    private PlayerInventory inventory;
    RecipeData recipeData;
    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        recipeData = GameObject.FindWithTag("PlayerData").GetComponent<RecipeData>();
    }
    void OnEnable()
    {
        book.SetActive(true);
        cookButton.SetActive(false);
        ReturnButton.SetActive(false);
        cookVideoObj.SetActive(false);
    }
    void Update()
    {
        Check(visibalRecepie);
        IconUpdate();
    }
    private void Check(int index)
    {
        book.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = recipeData.Icon(visibalRecepie);
        if (inventory.Contains(index))
        {
            cookButton.SetActive(true);
        }
        else
        {
            cookButton.SetActive(false);
        }
    }
    public void SetVisibalRecepie(int recepie)
    {
        visibalRecepie = recepie;
        IconUpdate();
    }
    public void StartCook()
    {
        StartCoroutine(Cooking());
    }
    public IEnumerator Cooking()
    {
        recipeData.UnlockedRecipe(visibalRecepie);
        book.SetActive(false);
        inventory.Reduce(visibalRecepie);
        recipeData.UnlockedRecipe(visibalRecepie);
        cookVideoObj.SetActive(true);
        VideoPlayer cookVideo = cookVideoObj.GetComponent<VideoPlayer>();
        cookVideo.clip = recipeData.Video(visibalRecepie);
        cookVideo.Play();
        float videoTime = (float)cookVideo.clip.length;
        yield return new WaitForSeconds(videoTime);
        ReturnButton.SetActive(true);
    }
    private void IconUpdate()
    {
        int[] needed = recipeData.GetRecipeList(visibalRecepie);
        int[] have = inventory.GetInventory();
        for (int i = 0; i < counts.Length; i++)
        {
            int item = needed[i];
            if (item > 0)
            {
                icons[i].SetActive(true);
                counts[i].text = "" + item;
                if (inventory.GetItem(i) < item)
                {
                    counts[i].color = new Color(255, 0, 0);
                }
                else
                {
                    counts[i].color = new Color(255, 255, 255);
                }
            }
            else
            {
                icons[i].SetActive(false);
            }

        }

    }
    public void cose()
    {
        gameObject.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<Player>().RefillHeals();
        Time.timeScale = 1f;
    }
   public void BookActive(bool state){
        book.SetActive(state);
   }
}

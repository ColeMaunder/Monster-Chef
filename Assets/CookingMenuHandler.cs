using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Video;
using System.Collections;
public class CookingMenuHandler : MonoBehaviour
{
    [SerializeField] bool cook = true;
    [SerializeField] GameObject book;
    [SerializeField] GameObject cookButton;
    [SerializeField] GameObject ReturnButton;
    [SerializeField] GameObject cookVideoObj;
    [SerializeField] GameObject endingScene;
    [SerializeField] GameObject[] RecepieTags;

    public TMP_Text[] counts;
    public GameObject[] icons;
    private int visibalRecepie = 0;
    private PlayerInventory inventory;
    RecipeData recipeData;
    void OnEnable()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        recipeData = GameObject.FindWithTag("PlayerData").GetComponent<RecipeData>();
        book.SetActive(true);
        cookButton.SetActive(false);
        ReturnButton.SetActive(false);
        cookVideoObj.SetActive(false);
        endingScene.SetActive(false);
    }
    void Update()
    {
        Check(visibalRecepie);
        IconUpdate();
        TagsUpdate();
    }
    private void Check(int index)
    {
        bool unlocked = recipeData.GetUnlockedRecipe(index);
        book.GetComponent<Image>().sprite = recipeData.Icon(visibalRecepie, unlocked);
        if (!unlocked && cook)
        {
            if (inventory.Contains(index))
            {
                cookButton.SetActive(true);
            }
            else
            {
                cookButton.SetActive(false);
            }
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
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1);
        Time.timeScale = 0f;
        print("Done");
        ReturnButton.SetActive(true);
    }
    public IEnumerator Ending()
    {
        endingScene.SetActive(true);
        VideoPlayer endingVideo = endingScene.GetComponent<VideoPlayer>();
        endingVideo.Play();
        float videoTime = (float)endingVideo.clip.length;
        Time.timeScale = 1f;
        yield return new WaitForSeconds(videoTime);
        Time.timeScale = 0f;
        endingScene.transform.GetChild(0).gameObject.SetActive(true);
        endingScene.transform.GetChild(1).gameObject.SetActive(true);
    }
    private void TagsUpdate()
    {
        RecepieTags[0].SetActive(true);
        for (int i = 1; i < RecepieTags.Length; i++)
        {
            if (recipeData.GetUnlockedRecipe(i - 1))
            {
                RecepieTags[i].SetActive(true);
            }
            else
            {
                RecepieTags[i].SetActive(false);
            }
        }
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
                if (inventory.GetItem(i) < item && !recipeData.GetUnlockedRecipe(visibalRecepie))
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
    public void InventoryCose()
    {
        gameObject.SetActive(false);
    }
    public void Cose()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void cookCose()
    {
        if (recipeData.GetUnlockedRecipe(2))
        {
            StartCoroutine(Ending());
        }
        else
        {
            gameObject.SetActive(false);
            GameObject UI = GameObject.FindWithTag("UI");
            GameObject invantory = UI.transform.GetChild(5).gameObject;
            GameObject menue = invantory.transform.GetChild(2).gameObject;
            UI.GetComponent<MenuHandler>().setInventoryScreenActive(true);
            invantory.GetComponent<InventoryHandeler>().ShowMenueScreen(true);
            menue.GetComponent<CookingMenuHandler>().SetVisibalRecepie(visibalRecepie);
        }

    }
    public void BookActive(bool state)
    {
        book.SetActive(state);
    }
    public void EndQuti(){
        GameObject.FindWithTag("UI").GetComponent<MenuHandler>().Quit();
    }
    public void FreePlay()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

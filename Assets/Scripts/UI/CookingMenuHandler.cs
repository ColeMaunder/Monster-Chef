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
    [SerializeField] AudioClip[] CookSounds;

    public TMP_Text[] counts;
    public GameObject[] icons;
    private int visibalRecepie = 0;
    private PlayerInventory inventory;
    RecipeData recipeData;
    AudioHandler sound;
    void OnEnable()
    {
        sound = GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>();
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
        sound.FaideOutWorldSound(5, 0);
        sound.setSoundEffect(CookSounds[0],1);
        book.SetActive(false);
        inventory.Reduce(visibalRecepie);
        recipeData.UnlockedRecipe(visibalRecepie);
        cookVideoObj.SetActive(true);
        VideoPlayer cookVideo = cookVideoObj.GetComponent<VideoPlayer>();
        cookVideo.clip = recipeData.Video(visibalRecepie);
        cookVideo.Play();
        yield return new WaitForSecondsRealtime(2);
        float videoTime = (float)cookVideo.clip.length;
        sound.SetLoop(false);
        sound.FaidBetweenWorldSound(CookSounds[1],1,5,1);
        yield return new WaitForSecondsRealtime(videoTime - 2);
        float audioTime = (float)CookSounds[1].length;
        yield return new WaitForSecondsRealtime(audioTime - videoTime - 1);
        ReturnButton.SetActive(true);
        sound.FaidInWorldSound(1, 4, 0);
        sound.WorldSoundOn(false, 1);
        sound.SetLoop(true);
        print("Done");
        
    }
    public IEnumerator Ending()
    {
        sound.FaidBetweenWorldSound(CookSounds[2],1,15,0);
        endingScene.SetActive(true);
        VideoPlayer endingVideo = endingScene.GetComponent<VideoPlayer>();
        endingVideo.Play();
        float videoTime = (float)endingVideo.clip.length;
        yield return new WaitForSecondsRealtime(videoTime);
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
            sound.WorldSoundOn(true, 0);
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
        PlayerData data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        sound.FaidBetweenWorldSound(data.GetSceneMusic(),1,5,0);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

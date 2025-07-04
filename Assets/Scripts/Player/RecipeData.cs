using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.Video;

public class RecipeData : MonoBehaviour
{
    [SerializeField] private List<int> unlockedRecipes = new List<int>();
    [SerializeField] private Sprite[] recepieIconsLocked;
    [SerializeField] private Sprite[] recepieIconsUnlocked;
    [SerializeField] private VideoClip[] recepieVideos;
    [SerializeField] private String[] recepieNames = { "Slime Sunday", "Kentucky Fried Frog Legs", "Vinghetti Mandranaise", "Catfish Sashimi", "Crayfish Bisque", "Roast Rusa" };
    [SerializeField] private String[] recepieTexts = {"A gelatinous sweet treat that will kickstart your monster meal journey.",
        "Inspired by the famed Kentucky frying methods, these bouncy strips of meat give a burst of energy to the consumer.",
        "A fresh approach to Italian cuisine, this meal is best eaten with an open mind and a large fork.",
        "","","",""};
    private int[,] recepieNeed = { { 20, 0, 10, 0, 2 }, { 30, 15, 10, 0, 4 }, { 3, 3, 3, 8, 1 }, { 0, 30, 40, 20, 4 }, { 50, 40, 40, 30, 4 }, { 60, 50, 50, 40, 4 } };
    public Sprite Icon(int index, bool unlocked)
    {
        if (unlocked){
            return recepieIconsUnlocked[index];  
        } else{ 
            return recepieIconsLocked[index];
        }
        
    }
    public VideoClip Video(int index)
    {
        return recepieVideos[index];
    }
    public string Texts(int index)
    {
        return recepieTexts[index];
    }
    public string Names(int index)
    {
        return recepieNames[index];
    }
    public int[] GetRecipeList(int index)
    {
        int[] output = { recepieNeed[index, 0], recepieNeed[index, 1], recepieNeed[index, 2], recepieNeed[index, 3], recepieNeed[index, 4]};
        return output;
    }
    public bool GetUnlockedRecipe(int iD)
    {
        return unlockedRecipes.Contains(iD);
    }

    public void UnlockedRecipe(int iD)
    {
        unlockedRecipes.Add(iD);
    }
    public int GetUnlockedRecipeCount()
    {
        return unlockedRecipes.Count;
    }


    /*public TextAsset Recipes;
    //[System.Serializable]
    public class Recipe{
        public int code;
        public string name;
        public int slime;
        public int frog;
        public int mandrake;
        public int green;
    }
    //[System.Serializable]
    public class RecipeList{
        public Recipe[] Recepies;
    }
    public RecipeList recipes= new RecipeList();
    void Start() {
       recipes = JsonUtility.FromJson<RecipeList>(Recipes.text);
    }
    public Recipe GetRecipeList(int index){
        return recipes.Recepies[index]; 
    }*/
}


using UnityEngine;
using System.Collections.Generic;
using System;

public class RecipeData : MonoBehaviour
{
    public bool[] unlockedRecipes = { false, false, false, false, false, false};
    public Sprite[] recepieIcons;
    public String[] recepieNames = {"Slime Sunday","Kentucky Fried Frog Legs","Vinghetti Mandranaise","Catfish Sashimi","Crayfish Bisque","Roast Rusa"};
    public String[] recepieTexts = {"A gelatinous sweet treat that will kickstart your monster meal journey.",
        "Inspired by the famed Kentucky frying methods, these bouncy strips of meat give a burst of energy to the consumer.",
        "A fresh approach to Italian cuisine, this meal is best eaten with an open mind and a large fork.",
        "","","",""};
    public int[,] recepieNeed = {{50,0,0,0,1},{20,30,0,0,4},{20,10,20,0,4},{0,30,40,20,4},{50,40,40,30,4},{60,50,50,40,4}};
    public Sprite Icon(int index)
    {
        return recepieIcons[index];
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
        int[] output = { recepieNeed[index, 0], recepieNeed[index, 1], recepieNeed[index, 2], recepieNeed[index, 3] };
        return output;
    }
    public bool GetUnlockedRecipe(int index)
    {
        return unlockedRecipes[index];
    }
    
    public void SetUnlockedRecipe(int index, bool status)
    {
        unlockedRecipes[index] = status;
    }
    
    public bool[] GetUnlockedRecipes(int[] index)
    {
        return unlockedRecipes;
    }
    public bool[] GetUnlockedRecipes(){
        return unlockedRecipes;
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


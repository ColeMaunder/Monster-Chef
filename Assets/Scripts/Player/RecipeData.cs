using UnityEngine;
using System.Collections.Generic;

public class RecipeData : MonoBehaviour
{
    public TextAsset Recipes;
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
    }
}


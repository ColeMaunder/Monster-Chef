using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int[] invantory= {0,0,0,0}; // 0: Slime chunks, 1: Mandrake Roots, 2: Frog Legs, 3: Green Vines
    private int[] droppedInvantory = {0,0,0,0}; // 0: Slime chunks, 1: Mandrake Roots, 2: Frog Legs, 3: Green Vines
    private bool hasDroppedInventory = false;
    public GameObject grave;
    private WeaponAttacks player;
    private RecipeData recipes;
    void Start()
    {
        player = GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>();
        recipes = GameObject.FindWithTag("PlayerData").GetComponent<RecipeData>();
    }
    private void PrintInventory(){
        print("Slime chunks: " + invantory[0]);
        print("Mandrake Roots: " + invantory[1]);
        print("Frog Legs: " + invantory[2]);
        print("Green Vines: " + invantory[3]);
    }
    public int GetEnemy(int count){
        return invantory[count];
    }
   public void AddItem(int item){
        invantory[item]++;
        player.IncGetUltCharge();
        //PrintInventory();
   }
   public void DropInventory(){
        droppedInvantory = invantory;
        for(int i=0;i<invantory.Length;i++){
            invantory[i]=   0;
        }
        Instantiate(grave, transform.position, Quaternion.identity);
        grave.GetComponent<PlayerGrave>().SetDroppedInventory(droppedInvantory);
        hasDroppedInventory = true;
        PrintInventory();
    }
    
     public void SetInventory(int[] invIn){
     invantory = invIn;
     }
    public int[] GetInventory(){
        return invantory;
    }
    public int GetItem(int index){
        return invantory[index];
    }

   public void PickUpInventory()
    {
        for (int i = 0; i < invantory.Length; i++)
        {
            invantory[i] += droppedInvantory[i];
        }
        droppedInvantory = null;
        hasDroppedInventory = false;
        PrintInventory();
    }
   
   public bool GethasDroppedInventory(){
        return hasDroppedInventory;
   }
   public void Reduce(int index){
        int[] used= {recipes.GetRecipeList(index).slime,recipes.GetRecipeList(index).mandrake,recipes.GetRecipeList(index).frog,recipes.GetRecipeList(index).green};
        for(int i=0;i<invantory.Length;i++){
            invantory[i] -= used[i];
        }
   }
   public bool Contains(int index){
        int[] required = {recipes.GetRecipeList(index).slime,recipes.GetRecipeList(index).mandrake,recipes.GetRecipeList(index).frog,recipes.GetRecipeList(index).green};
        bool contains = true;
        for(int i=0;i<invantory.Length;i++){
            if (invantory[i] < required[i]){
                contains = false;
            }
        }
        return contains;
   }
   
}

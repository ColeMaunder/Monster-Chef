using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int[] invantory= {0,0,0,0};
    private int[] droppedInvantory;
    private bool hasDroppedInventory = false;
    public GameObject grave;
    public WeaponAttacks player;
    void Start()
    {
        player = GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>();
    }
    private void PrintInventory(){
        print("Slime chunks: " + invantory[0]);
        print("Mandrake Roots: " + invantory[1]);
        print("Frog Legs: " + invantory[2]);
        print("Green Vines: " + invantory[3]);
    }
   public void AddItem(int item){
    invantory[item]++;
    player.IncGetUltCharge();
    PrintInventory();
   }
   public void DropInventory(){
    droppedInvantory = invantory;
    for(int i=0;i<invantory.Length;i++){
        invantory[i]=   0;
    }
    Instantiate(grave, transform.position, Quaternion.identity);
    hasDroppedInventory = true;
    PrintInventory();
   }

   public void PickUpInventory(){
    for(int i=0;i<invantory.Length;i++){
        invantory[i] += droppedInvantory[i];
    }
    droppedInvantory = null;
    hasDroppedInventory = false;
    PrintInventory();
   }
   
   public bool GethasDroppedInventory(){
    return hasDroppedInventory;
   }

   
}

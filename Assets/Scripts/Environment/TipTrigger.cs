using TMPro;
using UnityEngine;

public class TipTrigger : MonoBehaviour
{
    public GameObject tipUI; // The tip GameObject to be displayed
    private TMP_Text tipMessage; // The TextMeshPro text that will display the messages
    public int tipCode; // Receves the curintly relivent messages's code
    private string [] tips = { "WASD to move", "SPACE to dash", "MB1 to do a light attack",
    "Do a series of light attacks to do a combo move", "MB2 to do a Heavy Attack, hold to charge for more power",
    "Heavy Attacks can hit multiple enemies", "use R to consume one healing resource",
    "E to Interact. Interact with fountains to refill healing, health and set spawn point", "Q to do a Special Attack when your special bar is full",
    "Well Done! you found a recipe, head back to your restaurant to cook a meal","Later you will be able to store extra ingredients in the pantry",
    "Press E to cook your new recipe that will give you a buff","test out your new health buff: Health increased"}; // Stores all the possible messages
    void Start()
    {
        tipUI.SetActive(false); // Ensure the tip is not displayed at the start
        //tipUI = GameObject.FindWithTag("UITip");
        tipMessage = tipUI.GetComponent<TMP_Text>();

    }

    void OnTriggerEnter2D(Collider2D intip)
    {
        if (intip.CompareTag("Player"))
        {
            tipMessage.text = tips[tipCode]; // Changes the text to the appropriate message
            tipUI.SetActive(true); // Show the tip when the player is inside the trigger
            print("tip shown");
        }
    }
    void OnTriggerExit2D(Collider2D intip)
    {
        if (intip.CompareTag("Player"))
        {
            tipMessage.text = ""; // Removes the no longer relevant message
            try{
            tipUI.SetActive(false); // Hide the tip when the player exits the trigger
            }catch(MissingReferenceException){
            }
        }
    }

}

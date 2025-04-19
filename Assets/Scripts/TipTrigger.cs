using UnityEngine;

public class TipTrigger : MonoBehaviour
{
    public GameObject tipUI; // The tip GameObject to be displayed
    void Start()
    {
        tipUI.SetActive(false); // Ensure the tip is not displayed at the start
    }

    void OnTriggerEnter2D(Collider2D intip)
    {
        if (intip.CompareTag("Player"))
        {
            tipUI.SetActive(true); // Show the tip when the player is inside the trigger
        }
    }
    void OnTriggerExit2D(Collider2D intip)
    {
        if (intip.CompareTag("Player"))
        {
            tipUI.SetActive(false); // Hide the tip when the player exits the trigger
        }
    }

}

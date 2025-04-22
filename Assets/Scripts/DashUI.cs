using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    PlayerMovment player;
    public Image cooldownImage;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dash UI stuff
        if (player.GetCooldownTimer() > 0f){
            player.DeIncCooldownTimer();
            if (player.GetCooldownTimer()<= 0f){
                player.SetcooldownTimer(0f); // Reset the image fill amount
            } else {
                cooldownImage.fillAmount = player.GetCooldownTimer() / player.GetDashCool(); // Update the image fill amount
            }
        } else {
            cooldownImage.fillAmount = 0f; // Reset the image fill amount
        }

    }
    
}

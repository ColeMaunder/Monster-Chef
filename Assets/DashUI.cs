using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    PlayerMovment player;
    private float cooldownTimer = 0f;
    public Image cooldownImage;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetIsDash()){
            cooldownTimer = player.GetDashCool();
        }
        
        //Dash UI stuff
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                cooldownTimer = 0f; // Reset the image fill amount
            }
            else
            {
                cooldownImage.fillAmount = cooldownTimer / player.GetDashCool(); // Update the image fill amount
            }
        }
        else
        {
            cooldownImage.fillAmount = 0f; // Reset the image fill amount
        }

    }
    
}

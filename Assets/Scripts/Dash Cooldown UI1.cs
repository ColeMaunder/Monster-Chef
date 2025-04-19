using UnityEngine;
using UnityEngine.UI;

public class DashCooldownUI1 : MonoBehaviour
{
    public Image cooldownImage;
    public float cooldownDuration = 5f; // Need to match player script cooldown duration
    private float cooldownTimer = 0f;
    private bool isCooldownActive = false;

    public void StartCooldown()
    {
        isCooldownActive = true;
        cooldownTimer = cooldownDuration;
    }

    void Update()
    {
        if (isCooldownActive)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                isCooldownActive = false;
                cooldownImage.fillAmount = 0f; // Reset the image fill amount
            }
            else
            {
                cooldownImage.fillAmount = cooldownTimer / cooldownDuration; // Update the image fill amount
            }
        }
    }
}

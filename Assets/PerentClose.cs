using UnityEngine;

public class PerentClose : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!transform.GetChild(0).gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
    
}

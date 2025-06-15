using UnityEngine;

public class PerentClose : MonoBehaviour
{
    [SerializeField] int[] watching = {0};
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            bool canClose = true;
            foreach (int i in watching)
            {
                if (transform.GetChild(i).gameObject.activeSelf)
                {
                    canClose = false;
                }
            }
            if(canClose){
                gameObject.SetActive(false);
                    Time.timeScale = 1f;
            }
            
        }
    }
    
}

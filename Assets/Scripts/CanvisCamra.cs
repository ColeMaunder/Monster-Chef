using UnityEngine;

public class CanvisCamra : MonoBehaviour
{
    void OnEnable(){
        Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // Or GameObject.Find("CameraName")
        gameObject.GetComponent<Canvas>().worldCamera = cam;  
    }
}

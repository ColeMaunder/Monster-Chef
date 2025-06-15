using UnityEngine;

public class Cooking : MonoBehaviour
{
    bool inRainge = false;
    public GameObject CookingScreen;
    void Start()
    {
        CookingScreen = transform.parent.GetChild(1).gameObject;
    }
    void Update()
    {
        if(inRainge){
            if (Input.GetKeyDown(KeyCode.E)){
                CookingScreen.SetActive(true);
                CookingScreen.transform.GetChild(0).gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            print("in");
            inRainge = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            inRainge = false;
        }
    }
}

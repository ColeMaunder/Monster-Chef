using Unity.VisualScripting;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    public HealsUI uI;
    Player player;
    bool inRainge = false;
    [SerializeField] private GameObject fountainUI;
    [SerializeField] private int index;
    private PlayerData data;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inRainge){
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.RefillHeals();
                player.RefillHealth();
                GameObject Respawn = GameObject.FindWithTag("Respawn");
                Respawn.transform.position = transform.position;
                print("fountain set");
                data.SetFountain(index, true);
                fountainUI.SetActive(true);
                fountainUI.transform.GetChild(0).gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "PlayerBody"){
            print("player in");
            inRainge = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "PlayerBody"){
            inRainge = false;
            Time.timeScale = 1f;
        }
    }
}

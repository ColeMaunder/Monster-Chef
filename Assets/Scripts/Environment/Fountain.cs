using Unity.VisualScripting;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    string fountainID;
    Player player;
    bool inRainge = false;
    [SerializeField] private GameObject fountainUI;
    private PlayerData data;
    [SerializeField]AudioClip clip;
    AudioHandler sound;
    void Start()
    {
        sound = GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>();
        fountainID = transform.parent.parent.gameObject.GetComponent<FountainID>().GetID();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inRainge){
            if (Input.GetKeyDown(KeyCode.E) && Time.timeScale >0)
            {
                player.RefillHeals();
                player.RefillHealth();
                sound.playSound(clip,transform,1);
                GameObject Respawn = GameObject.FindWithTag("Respawn");
                Respawn.transform.position = transform.position;
                print("fountain set");
                data.UnlockFountain(fountainID);
                data.setLastFountian(fountainID);
                fountainUI.SetActive(true);
                fountainUI.transform.GetChild(0).gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.tag == "PlayerBody"){
            print("player in");
            inRainge = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "PlayerBody"){
            inRainge = false;
            GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>().SetCahingID(data.GetNaturalSceneCahngeID());
            Time.timeScale = 1f;
        }
    }
}

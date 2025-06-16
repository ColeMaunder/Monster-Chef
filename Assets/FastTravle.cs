using UnityEngine;

public class FastTravle : MonoBehaviour
{
    Player player;
    SceneChanger scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scene = GameObject.FindWithTag("SceneChainger").GetComponent<SceneChanger>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    public void TravleTo(string FountainID){
        scene.SetCahingID(3);
        player.GoToFountain(FountainID);
    }
}

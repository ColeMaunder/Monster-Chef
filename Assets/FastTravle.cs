using UnityEngine;

public class FastTravle : MonoBehaviour
{
    Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    public void TravleTo(string FountainID){
        player.GoToFountain(FountainID);
    }
}

using TMPro;
using UnityEngine;

public class HealsUI : MonoBehaviour
{
    public TMP_Text healsCount;
    private Player player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healsCount.text =  player.GetHeals() + "";
    }
}

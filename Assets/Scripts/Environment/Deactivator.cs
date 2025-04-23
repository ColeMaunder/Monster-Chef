using UnityEngine;

public class Deactivator : MonoBehaviour
{
    void Start()
    {
     GameObject ui = GameObject.FindWithTag("UI");
     ui.SetActive(false);
     GameObject player = GameObject.FindWithTag("Player");
     player.SetActive(false);
    }
}

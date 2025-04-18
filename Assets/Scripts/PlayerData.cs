using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private string[] keysIn = {"up", "down", "right", "left", "e", "q"};
    public static string[] keys;
    private void keyUpdate(){
        keys = keysIn;
    }
     [SerializeField] private Sprite[] spritesIn = {};
    public static Sprite[] sprites;
    private void spriteUpdate(){
        sprites = spritesIn;
    }
    [SerializeField] private bool movmentMouseIn = false;
    public static bool movmentMouse;
    private void movmentMouseUpdate(){
       movmentMouse =  movmentMouseIn;
    } 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keyUpdate();
        spriteUpdate();
         movmentMouseUpdate();
    }
}

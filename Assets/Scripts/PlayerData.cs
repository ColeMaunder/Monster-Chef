using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerData : MonoBehaviour
{
    public string[] keys = {"up", "down", "right", "left", "e", "q"};
    public string GetKey(int keyCode){
        return keys[keyCode];
    }
    public void SetKey(int keyCode, string keyIn){
        keys[keyCode] = keyIn;
    }

    public Sprite GetSprite(int spriteCode){
        return sprites[spriteCode];
    }
    public Sprite[] sprites = {};
    
    
    public bool mouseMovment = false;

    public bool GetMouseMovment(){
        return mouseMovment;
    }

    public void SetMouseMovment(bool mouseMovmentIn){
        mouseMovment = mouseMovmentIn;
    }
    
    public PlayerData(){}
}

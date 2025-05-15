using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerData : MonoBehaviour
{
    public bool[] unlockedRecipes = {false,false,false,false,false,false,false};
    public bool GetUnlockedRecipe(int index){
        return unlockedRecipes[index];
    }
    public void SetUnlockedRecipe(int index, bool status){
        unlockedRecipes[index] = status;
    }
    public float moveSpeed = 5f;
    public float GetMoveSpeed(){
        return moveSpeed;
    }
    public float dashMod = 4f;
    public float GetDashMod(){
        return dashMod;
    }

    public float dashTime = 0.15f;
    public float GetDashTime(){
        return dashTime;
    }

    public float GetDashCool(){
        return dashCool;
    }

    private float cooldownTimer = 0f;
    public float GetCooldownTimer(){
        return cooldownTimer;
    }
    public void SetCooldownTimer(float timerIn){
        cooldownTimer  = timerIn;
    }

    public float DeIncCooldownTimer(){
        return cooldownTimer -= Time.deltaTime;
    }

    public void SetcooldownTimer(float cooldownTimerIn){
        cooldownTimer = cooldownTimerIn;
    }    
    public float dashCool = 1f;
    public string[] keys = {"up", "down", "right", "left", "e", "q"};
    public string GetKey(int keyCode){
        return keys[keyCode];
    }
    public void SetKey(int keyCode, string keyIn){
        keys[keyCode] = keyIn;
    }

    public AnimationClip[] GetAnimations(){
        return animations;
    }
    public AnimationClip[] animations = {};
    
    
    public bool mouseMovment = false;

    public bool GetMouseMovment(){
        return mouseMovment;
    }

    public void SetMouseMovment(bool mouseMovmentIn){
        mouseMovment = mouseMovmentIn;
    }
    
    public PlayerData(){}
}

using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerData : MonoBehaviour
{
    AudioHandler AudioHandler;
    void Start()
    {
        AudioHandler = GameObject.FindWithTag("SoundManager").GetComponent<AudioHandler>();
    }
    public AudioClip deathSound;
    public void playDeathSound(){
        AudioHandler.playSound(deathSound, transform, 1);
    }

    public AudioClip[] itemPickupSounds;
    public void playItemPickupSound(){
        AudioHandler.playRandomSound(itemPickupSounds, transform, 1);
    }
    public AudioClip healSound;
    public void playHealSound(){
        AudioHandler.playSound(healSound, transform, 1);
    }
    public AudioClip hurtSound;
    public void playHurtSound(){
        AudioHandler.playSound(hurtSound, transform, 1);
    }
    public AudioClip dashSound;
    public void playDashSound(){
        AudioHandler.playSound(dashSound, transform, 1);
    }
    public AudioClip walkSound;
    public AudioClip getWalkSound(){
        return walkSound;
    }

    public int activeWepon = 0;
    public int getActiveWepon(){
        return activeWepon;
    }
    public void setActiveWepon(int activeWeponIn){
        activeWepon = activeWeponIn;
    }

    private bool isDash = false;
    public bool getIsDash(){
        return isDash;
    }
    public void setIsDash(bool isDashIN){
        isDash = isDashIN;
    }
    private bool canMove = true;
    public bool getCanMove(){
        return canMove;
    }
    public void setCanMove(bool canMoveIn){
        canMove = canMoveIn;
    }
    private Vector2 moveDir;
    public Vector2 getMoveDir(){
        return moveDir;
    }
    public void setMoveDir(Vector2 moveDirIn){
        moveDir = moveDirIn;
    }
    public bool[] unlockedRecipes = { false, false, false, false, false, false, false };
    public bool GetUnlockedRecipe(int index){
        return unlockedRecipes[index];
    }
    public void SetUnlockedRecipe(int index, bool status){
        unlockedRecipes[index] = status;
    }
    public bool[] GetUnlockedRecipes(int[] index){
        return unlockedRecipes;
    }
    public bool[] GetUnlockedRecipes(){
        return unlockedRecipes;
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
}

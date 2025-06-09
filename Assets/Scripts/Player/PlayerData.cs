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
    public AudioClip[] itemPickupSounds;
    public AudioClip healSound;
    public AudioClip hurtSound;
    public AudioClip dashSound;
    public AudioClip walkSound;
    public int activeWepon = 0;
    private bool isDash = false;
    private bool canMove = true;
    private Vector2 moveDir;
    public Sprite[] recepieIcons;
    public Sprite[] recepieNames;
    public float moveSpeed = 5f;
    public string[] keys = {"up", "down", "right", "left", "e", "q"};
    public bool[] unlockedFountians = {false,false,false,false,false,false};
    public float dashCool = 1f;
    
    public void playDeathSound(){
        AudioHandler.playSound(deathSound, transform, 1);
    }
    
    public void playItemPickupSound(){
        AudioHandler.playRandomSound(itemPickupSounds, transform, 1);
    }
    
    public void playHealSound(){
        AudioHandler.playSound(healSound, transform, 1);
    }
    
    public void playHurtSound(){
        AudioHandler.playSound(hurtSound, transform, 1);
    }
    
    public void playDashSound(){
        AudioHandler.playSound(dashSound, transform, 1);
    }
    
    public AudioClip getWalkSound(){
        return walkSound;
    }
    
    public int getActiveWepon(){
        return activeWepon;
    }
    public void SetFountain(int index, bool state){
        unlockedFountians[index] = state;
    }
    public bool GetFountain(int index){
        return unlockedFountians[index];
    }
    public void setActiveWepon(int activeWeponIn)
    {
        activeWepon = activeWeponIn;
    }
    
    public bool getIsDash(){
        return isDash;
    }
    
    public void setIsDash(bool isDashIN)
    {
        isDash = isDashIN;
    }
    
    public bool getCanMove()
    {
        return canMove;
    }
    
    public void setCanMove(bool canMoveIn)
    {
        canMove = canMoveIn;
    }
    
    public Vector2 getMoveDir()
    {
        return moveDir;
    }
    
    public void setMoveDir(Vector2 moveDirIn)
    {
        moveDir = moveDirIn;
    }
    
    public float GetMoveSpeed()
    {
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
    
    public float GetDashCool()
    {
        return dashCool;
    }

    private float cooldownTimer = 0f;
    public float GetCooldownTimer(){
        return cooldownTimer;
    }
    
    public void SetCooldownTimer(float timerIn)
    {
        cooldownTimer = timerIn;
    }
    
    public float DeIncCooldownTimer()
    {
        return cooldownTimer -= Time.deltaTime;
    }
    
    public void SetcooldownTimer(float cooldownTimerIn)
    {
        cooldownTimer = cooldownTimerIn;
    } 
       
    public string GetKey(int keyCode)
    {
        return keys[keyCode];
    }
    
    public void SetKey(int keyCode, string keyIn)
    {
        keys[keyCode] = keyIn;
    }
    
    public bool mouseMovment = false;

    public bool GetMouseMovment(){
        return mouseMovment;
    }
    
    public void SetMouseMovment(bool mouseMovmentIn)
    {
        mouseMovment = mouseMovmentIn;
    }
}

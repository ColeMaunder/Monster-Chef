using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float health;
    public float maxHealth = 10f;
    int heals;
    public int maxHeals = 3;
    public float healAmount = 4f;
    PlayerInventory inventory;
    GameObject spawn;
    GameObject[] spawners;
    bool playerAlive = true;
    private CameraFollow cameraFollow;
    private PlayerData data;
    private MenuHandler menu;
    private float trapCounter = 0;
    private float tickCounter = 0;
    private float trapTickTime;
    private float trapTickDamage;
    private float trapTickEnd;
    //private int trapWrigleThreshold;
    private Rigidbody2D rb;
    private Animator Animator;
    HealsUI fountainUI;
    public bool GetPlayerAlive()
    {
        return playerAlive;
    }

    void Start()
    {
        Animator = transform.gameObject.GetComponent<Animator>();
        rb = transform.gameObject.GetComponent<Rigidbody2D>();
        menu = GameObject.FindWithTag("UI").GetComponent<MenuHandler>();
        health = maxHealth;
        heals = maxHeals;
        inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        data = GameObject.FindWithTag("PlayerData").GetComponent<PlayerData>();
        spawn = GameObject.FindWithTag("Respawn");
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        cameraFollow = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        menu.showDeathScreen(false);
        fountainUI = GameObject.FindWithTag("UI").transform.GetChild(0).GetChild(1).gameObject.GetComponent<HealsUI>();
    }
    void Update()
    {
        if (!playerAlive) {
            menu.showDeathScreen(true);
            //print ("still dead");
            if (Input.GetKeyDown(KeyCode.Return)) {
                print("alive");
                Respawn();
                Reset();
                Time.timeScale = 1f;
                playerAlive = true;
            }
        } else {
            if (Input.GetKeyDown(KeyCode.R)) {
                Heal();
            }
            if (data.getTrapped()) {
                Animator.SetBool("trapped", true);
                rb.linearVelocity = Vector2.zero;
                data.setCanMove(false);
                trapCounter += Time.deltaTime;
                /*if (){
                    trapWrigleThreshold--;
                }*/
                if (tickCounter >= trapTickEnd /*|| trapWrigleThreshold <= 0*/){
                    data.setTrapped(false);
                    data.setCanMove(true);
                    trapCounter = 0;
                    tickCounter = 0;
                    //trapWrigleThreshold = 0;
                    Animator.SetBool("trapped", false);
                } else if (trapCounter >= trapTickTime) {
                    tickCounter++;
                    damage(trapTickDamage);
                    trapCounter = 0;
                }
            } else {
                Animator.SetBool("trapped", false);
                trapCounter = 0;
                //trapCounter = 0;
                //data.setCanMove(true);
            }
        }
    }
    public void damage(float damage)
    {
        health -= damage;
        data.playHurtSound();
        cameraFollow.activateShake(30, 30, 30, 0.1f);
        print("curent health is " + health);
        if (health <= 0)
        {
            print("You are Dead");
            Dead();
        }
    }
    public void trapDamage(float initialDamage, float tickTime, float tickDamage, float tickEnd, int wrigleThreshold)
    {
        this.damage(initialDamage);
        tickCounter = 0;
        trapCounter = 0;
        trapTickTime = tickTime;
        trapTickDamage = tickDamage;
        trapTickEnd = tickEnd;
        //trapWrigleThreshold = wrigleThreshold;
        data.setTrapped(true);
    }
    public int GetHeals()
    {
        return heals;
    }

    public int GetMaxHeals()
    {
        return maxHeals;
    }
    private void Heal()
    {
        if (heals > 0)
        {
            data.playHealSound();
            float tempHp = health + healAmount;
            if (tempHp < maxHealth)
            {
                health += healAmount;
            }
            else
            {
                health = maxHealth;
            }
            heals--;
            print("your health is " + health);
        }
        print("you have " + heals + " healing items reminging");
    }
    private void Dead()
    {
        print("You Died");
        data.playDeathSound();
        playerAlive = false;
        Time.timeScale = 0f;
        
    }

    public void HealthFull()
    {
        health = maxHealth;
    }

    public void Respawn()
    {
        Reset();
        inventory.DropInventory();
        toRespawnPoint();
        health = maxHealth;
        heals = maxHeals;
        Time.timeScale = 1f;
        playerAlive = true;
        menu.showDeathScreen(false);

    }
    private void toRespawnPoint()
    {
        try{
            GoToFountain(data.getLastFountain());
        }catch(IndexOutOfRangeException ex){
            Debug.Log (ex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
    public void ToStart()
    {
        transform.position = spawn.transform.position;
        playerAlive = true;
    }

    public void Reset()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            Destroy(enemy);
        }
        GameObject[] drops = GameObject.FindGameObjectsWithTag("Drop");
        foreach (GameObject drop in drops)
        {
            Destroy(drop);
        }
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(true);
        }
        GameObject.FindWithTag("PlayerData").GetComponent<WeaponAttacks>().SetUltCharge(0);
    }

    public void RefillHeals()
    {
        heals = maxHeals;
        fountainUI.Fountain();
    }
    public void RefillHealth()
    {
        health = maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetMaxHealth(float healthIn)
    {
        maxHealth = healthIn;
    }
    public void UpdateAll()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        spawn = GameObject.FindWithTag("Respawn");
    }
    public void WipeAll()
    {
        spawners = null;
        spawn = null;
    }

    public void SetBoth(int[] inArr)
    {
        health = inArr[0];
        heals = inArr[1];
    }
    public void GoToFountain(string fountainID)
    {
        string scene = "";
            switch (fountainID[0])
            {
                case '0':
                    scene = "Start Tut Block";
                    break;
                case '1':
                    scene = "Village Area";
                    break;
                case '2':
                    scene = "Level 2";
                    break;
                case '3':
                    scene = "Boss Fight";
                    break;
            }
            if (SceneManager.GetActiveScene().name != scene){  
                SceneManager.LoadScene(scene);
            }
            GameObject[] fountains = GameObject.FindGameObjectsWithTag("Fountain");
        foreach (GameObject i in fountains)
        {
            if (i.GetComponent<FountainID>().GetID() == fountainID)
            {
                transform.position = spawn.transform.position = i.transform.GetChild(0).position;
                break;
            }
        }
    }

    
}
